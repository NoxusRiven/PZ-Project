using MiniWindowGameLib.Core;
using MiniWindowGameLib.Character;

namespace MiniWindowGameLib.Enemy
{
    public class Boss : Entity
    {
        public Skill SpecialAttack { get; set; }

        public Boss(string name, int level, int maxHp, int baseDamage, int str, int dex, int _int, int reduction, Skill specialAttack) :
            base(name, level, maxHp, baseDamage, str, dex, _int, reduction)
        {
            SpecialAttack = specialAttack;
        }
    }
}
