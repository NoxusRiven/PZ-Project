using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniWindowGameLib.Character;
using MiniWindowGameLib.Enemy;
using MiniWindowGameLib.Exception;

namespace MiniWindowGameLib.Core
{
    public class TurnAction
    {
        public Character.Character Character { get; set; }

        public Monster Target { get; set; }

        public Skill? Skill { get; set; }

        public bool IsAttack { get; set; }

        public TurnAction() { }
        public TurnAction(Character.Character character, Monster target, Skill? skill, bool isAttack)
        {
            Character = character;
            Target = target;
            Skill = skill;
            IsAttack = isAttack;
        }

        public void Execute()
        {
            if (Character == null)
                throw new NullCharacterException("Character was not selected when trying to attack enemy");

            if (IsAttack)
            {
                Target.TakeDamage(Character.Damage);
            }
            else if (Skill != null)
            {
                Skill.Activate(Target);
            }
        }
    }
}
