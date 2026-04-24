using MiniWindowGameLib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWindowGameLib.Enemy
{
    public class Wolf : Entity
    {
        public Wolf(string name, int level) : base(name, level, 100 + (level * 30), 15, 12 + (level * 5), 3, 3, 2)
        {
        }
    }
}
