using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWindowGameLib.Character
{
    public class Mage : Character
    {
        public int MaxMana { get; set; }
        public int CurrentMana { get; set; }

        public override int Damage => base.Damage + (int)(Inteligence * 1.1);

        public Mage(string name) :
            base(name, 1, 90, 20, 3, 3, 25, 3, 100)
        {
            MaxMana = 150;
            CurrentMana = MaxMana;
        }

        public override void LevelUp()
        {
            Level++;
            MaxHp += 15;
            MaxMana += 25;

            Dexterity += 1;
            Inteligence += 8;
            Strength += 1;
            MaxExp = (int)(MaxExp * 1.4);
        }
    }
}
