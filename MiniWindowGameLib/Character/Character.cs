using MiniWindowGameLib.Core;

namespace MiniWindowGameLib.Character
{
    public abstract class Character : Entity
    {
        public int MaxExp { get; set; }
        public int CurrentExp { get; set; }
        public int Gold { get; set; }

        public List<Skill> SkillList { get; set; }

        public Character(string name, int level, int maxHp, int baseDamage, int strength, int dexterity, int inteligence, int reduction, int maxExp) :
            base(name, level, maxHp, baseDamage, strength, dexterity, inteligence, reduction)
        {
            MaxExp = maxHp;
            CurrentExp = 0;

            SkillList = new List<Skill>();
        }

        public abstract void LevelUp();

        public void IncExp(int exp)
        {
            CurrentExp += exp;

            if (CurrentExp >= MaxExp)
            {
                CurrentExp = CurrentExp - MaxExp;
                LevelUp();
            }
        }
    }
}
