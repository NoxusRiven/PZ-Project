using MiniWindowGameLib.Core;
using System.Text;

namespace MiniWindowGameLib.Character
{
    //TODO: later maybe also add min resitance
    public abstract class Character : Entity
    {
        public int MaxResistance { get; set; }
        public int MaxExp { get; set; }
        public int CurrentExp { get; set; }
        public int Gold { get; set; }

        public List<Skill> SkillList { get; set; }


        public Character(string name, int level, int maxHp, int baseDamage, int strength, int dexterity, int inteligence, int maxReduction, int reduction, int maxExp) :
            base(name, level, maxHp, baseDamage, strength, dexterity, inteligence, reduction)
        {
            MaxResistance = maxReduction;

            MaxExp = maxExp;
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

        public override string ToString()
        {
            StringBuilder skills = new StringBuilder();
            foreach (var skill in SkillList)
            {
                skills.Append(skill.ToString() + "\n");
            }

            return  $"{Name} - Level {Level}\n" +
                    $"HP: {CurrentHp}/{MaxHp}\n" +
                    $"EXP: {CurrentExp}/{MaxExp}\n" +
                    $"Gold: {Gold}\n" +
                    $"DMG: {Damage}\n" +
                    $"DMG Reduction: {BaseResistance}\n" +
                    $"Skills:\n" +
                    $"{skills}";

        }
    }
}
