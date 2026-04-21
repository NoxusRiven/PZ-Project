using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWindowGameLib
{
    public class Warrior : Character
    {
        public override int Damage => base.Damage * (int)(Strength * 1.5);

        public Warrior(string name) :
            base(name, 1, 150, 20, 10, 5, 5, 8, 100)
        { }

        public override void LevelUp()
        {
            throw new NotImplementedException();
        }
    }
}
