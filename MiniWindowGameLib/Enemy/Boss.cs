using MiniWindowGameLib.Core;
using MiniWindowGameLib.Character;

namespace MiniWindowGameLib.Enemy
{
    public class Boss : Monster
    {
        public Skill SpecialAttack { get; set; }

        public Boss(string name, int level, int maxHp, int baseDamage, int str, int dex, int _int, int reduction, int exp, int gold, Skill specialAttack) :
            base(name, level, maxHp, baseDamage, str, dex, _int, reduction, exp, gold)
        {
            SpecialAttack = specialAttack;
        }
    }
}
