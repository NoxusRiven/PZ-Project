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
        List<Entity> enemies;

        List<Character> characters;

        public Form1()
        {
            InitializeComponent();

            enemies = new List<Entity>();

            characters = new List<Character>();
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

            if (difficulty == Difficulty.Easy)
            {
                // first level stage 1
                enemies.Add(new Goblin("Goblin1", 1));
                enemies.Add(new Goblin("Goblin2", 1));
                enemies.Add(new Wolf("Wolf1", 1));

                // first level stage 2
                enemies.Add(new Goblin("Goblin1", 2));
                enemies.Add(new Goblin("Goblin2", 2));
                enemies.Add(new Wolf("Wolf1", 2));

                // second level stage 1
                enemies.Add(new Orc("Orc1", 4));
                enemies.Add(new Troll("Troll1", 3));

                // second level stage 2
                enemies.Add(new Orc("Orc1", 5));
                enemies.Add(new Troll("Troll1", 4));
                enemies.Add(new Troll("Troll2", 3));

                // boss fight
                var dragon = new Dragon("Dragon1", 10, new Skill("Dragon Breath", 50));
                dragon.SpecialAttack.OnUse += characters =>
                {
                    foreach (var c in characters)
                    {
                        c.TakeDamage(dragon.Inteligence * 2);
                    }
                };


            }
            else if (difficulty == Difficulty.Medium)
            {
                // first level stage 1
                enemies.Add(new Goblin("Goblin1", 1));
                enemies.Add(new Goblin("Goblin2", 2));
                enemies.Add(new Wolf("Wolf1", 1));

                // first level stage 2
                enemies.Add(new Goblin("Goblin1", 3));
                enemies.Add(new Goblin("Goblin2", 3));
                enemies.Add(new Wolf("Wolf1", 2));

                // second level stage 1
                enemies.Add(new Orc("Orc1", 4));
                enemies.Add(new Orc("Orc1", 3));
                enemies.Add(new Troll("Troll1", 3));

                // second level stage 2
                enemies.Add(new Orc("Orc1", 5));
                enemies.Add(new Troll("Troll1", 5));
                enemies.Add(new Troll("Troll2", 4));

                // boss fight
                var dragon = new Dragon("Dragon1", 12, new Skill("Dragon Breath", 50));
                dragon.SpecialAttack.OnUse += characters =>
                {
                    foreach (var c in characters)
                    {
                        c.TakeDamage((int)(dragon.Inteligence * 2.2));
                    }
                };
            }
            else if (difficulty == Difficulty.Hard)
            {
                // first level stage 1
                enemies.Add(new Goblin("Goblin1", 2));
                enemies.Add(new Goblin("Goblin2", 1));
                enemies.Add(new Wolf("Wolf1", 2));
                enemies.Add(new Wolf("Wolf1", 1));

                // first level stage 2
                enemies.Add(new Goblin("Goblin1", 4));
                enemies.Add(new Goblin("Goblin2", 3));
                enemies.Add(new Wolf("Wolf1", 3));

                // second level stage 1
                enemies.Add(new Orc("Orc1", 4));
                enemies.Add(new Troll("Troll1", 4));
                enemies.Add(new Troll("Troll2", 3));

                // second level stage 2
                enemies.Add(new Orc("Orc1", 6));
                enemies.Add(new Troll("Troll1", 5));
                enemies.Add(new Troll("Troll2", 5));

                // boss fight
                var dragon = new Dragon("Dragon1", 15, new Skill("Dragon Breath", 50));
                dragon.SpecialAttack.OnUse += characters =>
                {
                    foreach (var c in characters)
                    {
                        c.TakeDamage((int)(dragon.Inteligence * 2.5));
                    }
                };
            }

            StartGame();
        }

        private void StartGame()
        {
            SwapPanels(gamePanel, diffPanel);
        }

    }
}
