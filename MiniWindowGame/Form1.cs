using MiniWindowGameLib.Character;
using MiniWindowGameLib.Core;
using MiniWindowGameLib.Enemy;

namespace MiniWindowGame
{
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    public partial class Form1 : Form
    {
        List<Character> characters;
        List<Biome> biomes;

        public Form1()
        {
            InitializeComponent();

            InitObjects();
        }

        private void InitObjects()
        {
            startPanel.Visible = true;
            diffPanel.Visible = false;
            gamePanel.Visible = false;


            characters = new List<Character>();
            biomes = new List<Biome>();

            UpdateUI();
        }

        private void UpdateUI()
        {
            characterList.Items.Clear();

            foreach (var c in characters)
            {
                characterList.Items.Add(c.Name);
            }
        }

        // Start Panel
        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            SwapPanels(diffPanel, startPanel);
        }

        // Difficulty Panel
        private void easyBtn_Click(object sender, EventArgs e)
        {
            InitGame(Difficulty.Easy);
        }

        private void mediumBtn_Click(object sender, EventArgs e)
        {
            InitGame(Difficulty.Medium);
        }

        private void hardBtn_Click(object sender, EventArgs e)
        {
            InitGame(Difficulty.Hard);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            SwapPanels(startPanel, diffPanel);
        }


        // Game Panel
        public void InitGame(Difficulty difficulty)
        {
            characters.Add(new Warrior("Leonidas"));
            characters.Add(new Archer("Hicky"));
            characters.Add(new Mage("Merlin"));

            biomes.Add(new Biome("Forest"));
            biomes.Add(new Biome("Mountains"));
            biomes.Add(new Biome("Cave"));

            if (difficulty == Difficulty.Easy)
            {
                // forest stage 1
                biomes[0].Monsters.Add(new Goblin("Goblin1", 1));
                biomes[0].Monsters.Add(new Goblin("Goblin2", 1));
                biomes[0].Monsters.Add(new Wolf("Wolf1", 1));

                // forest stage 2
                biomes[0].Monsters.Add(new Goblin("Goblin1", 2));
                biomes[0].Monsters.Add(new Goblin("Goblin2", 2));
                biomes[0].Monsters.Add(new Wolf("Wolf1", 2));

                // mountains stage 1
                biomes[1].Monsters.Add(new Orc("Orc1", 4));
                biomes[1].Monsters.Add(new Troll("Troll1", 3));

                // mountains stage 2
                biomes[1].Monsters.Add(new Orc("Orc1", 5));
                biomes[1].Monsters.Add(new Troll("Troll1", 4));
                biomes[1].Monsters.Add(new Troll("Troll2", 3));

                // cave boss fight
                var dragon = new Dragon("Dragon1", 10, new Skill("Dragon Breath", 50));
                dragon.SpecialAttack.OnUse += targets =>
                {
                    foreach (var target in targets)
                    {
                        target.TakeDamage(dragon.Inteligence * 2);
                    }
                };
                biomes[2].Monsters.Add(dragon);


            }
            else if (difficulty == Difficulty.Medium)
            {
                // forest stage 1
                biomes[0].Monsters.Add(new Goblin("Goblin1", 1));
                biomes[0].Monsters.Add(new Goblin("Goblin2", 2));
                biomes[0].Monsters.Add(new Wolf("Wolf1", 1));

                // forest stage 2
                biomes[0].Monsters.Add(new Goblin("Goblin1", 3));
                biomes[0].Monsters.Add(new Goblin("Goblin2", 3));
                biomes[0].Monsters.Add(new Wolf("Wolf1", 2));

                // mountains stage 1
                biomes[1].Monsters.Add(new Orc("Orc1", 4));
                biomes[1].Monsters.Add(new Orc("Orc1", 3));
                biomes[1].Monsters.Add(new Troll("Troll1", 3));

                // mountains stage 2
                biomes[1].Monsters.Add(new Orc("Orc1", 5));
                biomes[1].Monsters.Add(new Troll("Troll1", 5));
                biomes[1].Monsters.Add(new Troll("Troll2", 4));

                // cave boss fight
                var dragon = new Dragon("Dragon1", 12, new Skill("Dragon Breath", 50));
                dragon.SpecialAttack.OnUse += characters =>
                {
                    foreach (var c in characters)
                    {
                        c.TakeDamage((int)(dragon.Inteligence * 2.2));
                    }
                };

                biomes[2].Monsters.Add(dragon);
            }
            else if (difficulty == Difficulty.Hard)
            {
                // forest stage 1
                biomes[0].Monsters.Add(new Goblin("Goblin1", 2));
                biomes[0].Monsters.Add(new Goblin("Goblin2", 1));
                biomes[0].Monsters.Add(new Wolf("Wolf1", 2));
                biomes[0].Monsters.Add(new Wolf("Wolf1", 1));

                // forest stage 2
                biomes[0].Monsters.Add(new Goblin("Goblin1", 4));
                biomes[0].Monsters.Add(new Goblin("Goblin2", 3));
                biomes[0].Monsters.Add(new Wolf("Wolf1", 3));

                // mountains stage 1
                biomes[1].Monsters.Add(new Orc("Orc1", 4));
                biomes[1].Monsters.Add(new Troll("Troll1", 4));
                biomes[1].Monsters.Add(new Troll("Troll2", 3));

                // mountains stage 2
                biomes[1].Monsters.Add(new Orc("Orc1", 6));
                biomes[1].Monsters.Add(new Troll("Troll1", 5));
                biomes[1].Monsters.Add(new Troll("Troll2", 5));

                // cave boss fight
                var dragon = new Dragon("Dragon1", 15, new Skill("Dragon Breath", 50));
                dragon.SpecialAttack.OnUse += characters =>
                {
                    foreach (var c in characters)
                    {
                        c.TakeDamage((int)(dragon.Inteligence * 2.5));
                    }
                };
                
                biomes[2].Monsters.Add(dragon);

            }

            StartGame();
        }

        private void StartGame()
        {
            SwapPanels(gamePanel, diffPanel);

            UpdateUI();
        }

    }
}
