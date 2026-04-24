using MiniWindowGameLib.Core;

namespace MiniWindowGameLib.Enemy
{
    public class Dragon : Boss
    {
        public Dragon(string name, int level, Skill skill) :
            base(name, level, 500 + (level * 100), 30, 20 + (level * 7), 5, 25 + (level * 5), 10, skill)
        {
        }
    }
}
