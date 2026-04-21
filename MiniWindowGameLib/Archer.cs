using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWindowGameLib
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
            throw new NotImplementedException();
        }
    }
}
