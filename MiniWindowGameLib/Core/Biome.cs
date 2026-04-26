using MiniWindowGameLib.Enemy;
using System.Text;

namespace MiniWindowGameLib.Core
{
    public enum BiomeType
    {
        Forest,
        Mountains,
        Cave,
    }

    public class Biome
    {
        public string Name { get; set; }
        public List<List<Monster>> Monsters { get; set; }

        //maybe later add biome buffs/debuffs

        public Biome(string name, List<List<Monster>> monsters)
        {
            Name = name;
            Monsters = monsters;
        }

        public Biome(string name)
        {
            Name = name;
            Monsters = new List<List<Monster>>();
        }

        public override string ToString()
        {
            StringBuilder monsters = new StringBuilder();
            int i = 1;
            foreach (var monsterList in Monsters)
            {
                monsters.Append($"-Stage {i}:\n");
                foreach (var monster in monsterList)
                {
                    monsters.Append(monster.ToString() + '\n');
                }

                i++;
            }

            return  $"Biome: {Name}\n" +
                    "Monsters:\n" +
                    $"{monsters}";
        }
    }
}
