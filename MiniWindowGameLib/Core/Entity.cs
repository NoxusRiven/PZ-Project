using System.Runtime.CompilerServices;

namespace MiniWindowGameLib.Core
{
    public abstract class Entity
    {
        public string Name { get; set; }
        public int Level { get; set; }


        public int MaxHp { get; set; }
        public int CurrentHp { get; set; }

        public int BaseDamage { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Inteligence { get; set; }

        public int BaseResistance { get; set; }

        public virtual int Resistance => BaseResistance;
        virtual public int Damage => (int)(BaseDamage * Level * 1.5);
        public bool IsAlive => CurrentHp > 0;

        public Entity(string name, int level, int maxHp, int baseDamage, int strength, int dexterity, int inteligence, int reduction)
        {
            Name = name;
            Level = level;
            MaxHp = maxHp;
            CurrentHp = maxHp;
            BaseDamage = baseDamage;
            Strength = strength;
            Dexterity = dexterity;
            Inteligence = inteligence;
            BaseResistance = reduction;
        }

        public virtual void TakeDamage(int damage)
        {
            CurrentHp -= damage / BaseResistance;
        }
    }

}
