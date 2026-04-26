using MiniWindowGameLib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWindowGameLib.Character
{
    public class Warrior : Character
    {
        public override int Damage => base.Damage + (int)(Strength * 1.5);
        public override int Resistance => Math.Min(base.Resistance + (Inteligence + Dexterity)/5, MaxResistance);

        public Warrior(string name) :
            base(name, 1, 150, 20, 10, 5, 5, 18, 8, 100)
        {
            var rage = new Skill("Spartan rage", 20);
            rage.OnUse += (targets) =>
            {
                if (CurrentHp > rage.Cost)
                    CurrentHp -= rage.Cost;
                else
                {
                    //inform about not enough hp
                    return;
                }
                foreach (var t in targets)
                {
                    t.Buff(BuffType.Damage, 15, 3);
                }
            };
            SkillList.Add(rage);
        }

        public override void LevelUp()
        {
            Level++;
            MaxHp += 50;

            Dexterity += 4;
            Inteligence += 4;
            Strength += 7;

            MaxExp = (int)(MaxExp * 1.4);
            CurrentHp = MaxHp;
        }

        public override string ToString()
        {
            return "Class: Warrior\n" +
                    base.ToString();
        }
    }
}
