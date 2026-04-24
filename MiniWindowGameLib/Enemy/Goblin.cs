using MiniWindowGameLib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWindowGameLib.Enemy
{
    public class Goblin : Entity
    {
        public Goblin(string name, int level) : base(name, level, 80 * level, level * 6, 10 + (level * 4), 2, 2, 1)
        {
        }
    }
}
