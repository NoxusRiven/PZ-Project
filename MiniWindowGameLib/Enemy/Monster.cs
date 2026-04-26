using MiniWindowGameLib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWindowGameLib.Enemy
{

    public abstract class Monster : Entity
    { 
        public int ExperienceReward { get; set; }
        public int GoldReward { get; set; }

        public Monster(string name, int level, int maxHP, int baseDmg, int str, int dex, int _int, int resist, int exp, int gold) : 
            base(name, level, maxHP, baseDmg, str, dex, _int, resist)
        { }

        public override string ToString()
        {
            return  $"Name {Name}\n" +
                    $"Level {Level}\n" +
                    $"Damage {Damage}\n" +
                    $"HP {MaxHp}\n";
        }
    }
}
