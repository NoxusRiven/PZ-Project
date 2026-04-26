using MiniWindowGameLib.Core;

namespace MiniWindowGameLib.Character
{
    public class Archer : Character
    {
        private const int skillUsageCount = 3;

        public int Luck { get; set; }
        public int SkillsLeft { get; set; }
        public override int Damage => base.Damage + (int)(Dexterity * 1.25);
        public override int Resistance => Math.Min(base.Resistance + (Inteligence + Strength)/8, MaxResistance);

        public Archer(string name) :
            base(name, 1, 100, 20, 5, 10, 5, 12, 5, 100)
        {
            Luck = 15;
            SkillsLeft = skillUsageCount;

            var arrowStorm = new Skill("Arrow storm", 1);
            arrowStorm.OnUse += (targets) =>
            {
                if (SkillsLeft > 0)
                    SkillsLeft--;
                else
                {
                    //inform about being unable to use skill
                    return;
                }

                int dmg = (Dexterity * Level/2);
                if (GotLucky())
                    dmg *= 2;

                foreach (var target in targets)
                {
                    target.TakeDamage(dmg);
                }                
            };

        }

        public bool GotLucky()
        {
            return new Random().Next(1, 100) <= Luck;
        }

        public int DealDamage()
        {
            int dmg = Damage;
            if (GotLucky())
                dmg *= 2;

            return dmg;
        }

        public void ResetSkillUsage()
        {
            SkillsLeft = skillUsageCount;
        }

        public override void TakeDamage(int damage)
        {
            if(GotLucky())
            {
                //inform about dodged attack
                return;
            }
            base.TakeDamage(damage);
        }

        public override void LevelUp()
        {
            Level++;
            MaxHp += 25;
            Dexterity += 5;
            Inteligence += 3;
            Strength += 3;
            MaxExp = (int)(MaxExp * 1.4);
        }

        public override string ToString()
        {
            return "Class: Archer\n" +
                    base.ToString() +
                    "Class stats:\n" + 
                    $"Luck: {Luck}\n" +
                    $"Skill usage count: {skillUsageCount}\n";
        }

    }
}
