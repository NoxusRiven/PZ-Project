using MiniWindowGameLib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWindowGameLib.Enemy
{
    public class Troll : Entity
    {
        public Troll(string name, int level) : base(name, level, 140 + (level * 40), 20, 15 + (level * 6), 5, 5, 3)
        {
        }
    }
}
