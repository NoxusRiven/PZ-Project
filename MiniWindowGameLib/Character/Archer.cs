using System;
using System.Collections.Generic;
using System.Linq;
namespace MiniWindowGameLib.Character
{
    public class Archer : Character
    {
        public override int Damage => base.Damage * (int)(Dexterity * 1.25);

        public Archer(string name) :
            base(name, 1, 100, 20, 5, 10, 5, 5, 100)
        {

        }

        public override void LevelUp()
        {
            Level++;
            MaxHp += 25;
            Dexterity += 5;
            Inteligence += 1;
            Strength += 1;
            MaxExp = (int)(MaxExp * 1.4);
        }
    }
}
