using MiniWindowGameLib.Character;

namespace MiniWindowGameLib.Core
{
    public delegate void SkillHandler(params Character.Character[] characters);
    
    public class Skill
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public event SkillHandler OnUse;

        public Skill(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        // activates skill on a character, deals dmg, heals, buffs ect.
        public void Activate(Character.Character c)
        {
            OnUse?.Invoke(c);
        }
    }
}
