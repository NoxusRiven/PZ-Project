using MiniWindowGameLib.Core;

namespace MiniWindowGameLib.Enemy
{
    public class Orc : Entity
    {
        public Orc(string name, int level) : base(name, level, 180 + (level * 65), 14, 12 + (level * 3), 5, 5, 5)
        {
        }
    }
}
