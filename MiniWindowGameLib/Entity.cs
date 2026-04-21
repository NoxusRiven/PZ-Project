using System.Runtime.CompilerServices;

namespace MiniWindowGameLib
{
    public abstract class Entity
    {
        public string Name { get; set; }
        public int Level { get; set; }

        
        public int MaxHp { get; set; }
        public int CurrentHp { get; set; }

        private int BaseDamage { get; set; }
        public int Strength { get; set; }
        public int Dexterity {  get; set; }
        public int Inteligence {  get; set; }

        public int Reduction {  get; set; }

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
            Reduction = reduction;
        }
        
        void TakeDamage(int damage)
        {
            CurrentHp -= (int)(damage / Reduction);
        }
    }

}
