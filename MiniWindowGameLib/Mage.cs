using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWindowGameLib
{
    public class Mage : Character
    {
        public int MaxMana { get; set; }
        public int CurrentMana { get; set; }

        public override int Damage => base.Damage + (int)(Inteligence * 1.1);

        public Mage(string name) : 
            base(name, 1, 90, 20, 3, 3, 25, 3, 100)
        { }

        public override void LevelUp()
        {
            throw new NotImplementedException();
        }
    }
}
