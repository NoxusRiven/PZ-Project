
namespace MiniWindowGameLib.Core
{
    public delegate void SkillHandler(params Entity[] targets);
    
    public class Skill
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int TurnDuration { get; set; }
        public event SkillHandler OnUse;

        public Skill(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        // activates skill on a character, deals dmg, heals, buffs ect.
        public void Activate(params Entity[] targets)
        {

            OnUse?.Invoke(targets);
        }

        public override string ToString()
        {
            return $"{Name} (Mana Cost: {Cost})";
        }

    }
    public enum BuffType
    {
        Damage,
        Resistance,
    }

    public static class SkillExtensions
    {
        

        public static void ReduceResistance(this Entity target, int reduction, int duration)
        {
            target.BaseResistance = Math.Max(0, target.BaseResistance - reduction);
        }

        public static void Heal(this Entity target, int amount)
        {
            target.CurrentHp = Math.Min(target.MaxHp, target.CurrentHp + amount);
        }

        public static void Buff(this Entity target, BuffType type, float procentageValue, int duration)
        {
            switch (type)
            {
                case BuffType.Damage:
                    target.BaseDamage = (int)(target.BaseDamage * procentageValue);
                    break;

                case BuffType.Resistance:
                    target.BaseResistance = (int)(target.BaseResistance * procentageValue);
                    break;
            }
        }
    }
}
