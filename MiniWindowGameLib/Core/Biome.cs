using MiniWindowGameLib.Enemy;

namespace MiniWindowGameLib.Core
{
    public class Biome
    {
        public string Name { get; set; }
        public List<Monster> Monsters { get; set; }

        //maybe later add biome buffs/debuffs

        public Biome(string name, List<Monster> monsters)
        {
            Name = name;
            Monsters = monsters;
        }

        public Biome(string name)
        {
            Name = name;
            Monsters = new List<Monster>();
        }
    }
}
