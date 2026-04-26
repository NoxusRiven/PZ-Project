using MiniWindowGameLib.Core;

namespace MiniWindowGameLib.Character
{
    public class Mage : Character
    {
        public int MaxMana { get; set; }
        public int CurrentMana { get; set; }

        public override int Damage => base.Damage + (int)(Inteligence * 1.1);
        public override int Resistance => 
            Math.Min(base.Resistance + (Strength + Dexterity)/10, MaxResistance);

        public Mage(string name) :
            base(name, 1, 90, 20, 3, 3, 25, 10, 3, 100)
        {
            MaxMana = 150;
            CurrentMana = MaxMana;

            var fireBall = new Skill("Fireball", 30);
            fireBall.OnUse += (targets) =>
            {
                if(CurrentMana >= fireBall.Cost)
                    CurrentMana -= fireBall.Cost;
                else
                {
                    //inform about not enough mana
                    return;
                }

                foreach (var target in targets)
                {
                    target.TakeDamage((Inteligence * Level) / 2 + fireBall.Cost);
                    target.ReduceResistance(Math.Min(5, 1 + Level / 5), 3);
                }
            };

            var boost = new Skill("Boost", 50);
            boost.OnUse += (targets) =>
            {
                foreach (var target in targets)
                {
                    if (target == this)
                    {
                        CurrentMana = Math.Min(CurrentMana + boost.Cost, MaxMana);
                        continue;
                    }
                    target.TakeDamage((Inteligence * Level) / 3 + boost.Cost);
                    target.ReduceResistance(Math.Min(10, 2 + Level / 5), 5);
                }
            };

            SkillList.Add(fireBall);
            SkillList.Add(boost);
        }

        public override void LevelUp()
        {
            Level++;
            MaxHp += 15;
            MaxMana += 25;

            Dexterity += 2;
            Inteligence += 8;
            Strength += 2;

            MaxExp = (int)(MaxExp * 1.4);
            CurrentHp = MaxHp;
            CurrentMana = MaxMana;
        }

        public override string ToString()
        {
            return "Class: Mage\n" +
                    base.ToString() +
                    "Class stats:\n" +
                    $"Mana: {CurrentMana}/{MaxMana}\n";
        }
    }
}
