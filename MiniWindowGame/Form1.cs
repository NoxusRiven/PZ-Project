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
        Dictionary<BiomeType, Biome> biomes;

        BiomeType? selectedBiome;

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
            fightPanel.Visible = false;


            characters = new List<Character>();
            biomes = new Dictionary<BiomeType, Biome>();

            selectedBiome = null;

            UpdateCharacterList();
        }

        private void AddNewLabel(string text, int fontSize, Point location, Control parent)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.Font = new Font(lbl.Font.FontFamily, fontSize);
            lbl.AutoSize = true;
            lbl.Location = location;

            parent.Controls.Add(lbl);
        }

        private void UpdateCharacterList()
        {
            characterList.Items.Clear();

            foreach (var c in characters)
            {
                characterList.Items.Add(c);
            }
            characterList.DisplayMember = "Name";
        }

        private void UpdateBiomeDescription()
        {
            biomeDescPanel.Controls.Clear();

            if (selectedBiome == null)
            {
                AddNewLabel("Select a biome to see its description.", 8, new Point(15, 30), biomeDescPanel);
                return;
            }

            Biome biome = biomes[selectedBiome.Value];

            string[] infoSplit = biome.ToString().Split('\n');

            int y = 5;
            int x = 15;
            int baseX = x;
            bool lastDash = false;
            foreach (string info in infoSplit)
            {
                if (lastDash)
                {
                    x += 15;
                    lastDash = false;
                }
                if (info.StartsWith("-"))
                {
                    lastDash = true;
                    x = 2 * baseX;
                }

                AddNewLabel(info, 8, new Point(x, y), biomeDescPanel);

                y += 20;
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
        private void AddStages(BiomeType biomeKey, List<Monster> stageOne, List<Monster> stageTwo)
        {
            biomes[biomeKey].Monsters.Add(stageOne);
            biomes[biomeKey].Monsters.Add(stageTwo);
        }

        private void InitGame(Difficulty difficulty)
        {
            characters.Add(new Warrior("Leonidas"));
            characters.Add(new Archer("Hicky"));
            characters.Add(new Mage("Merlin"));

            biomes.Add(BiomeType.Forest, new Biome("Forest"));
            biomes.Add(BiomeType.Mountains, new Biome("Mountains"));
            biomes.Add(BiomeType.Cave, new Biome("Cave"));

            if (difficulty == Difficulty.Easy)
            {
                // forest
                AddStages(BiomeType.Forest,
                    new List<Monster>
                    {
                        new Goblin("Goblin1", 1),
                        new Goblin("Goblin2", 1),
                        new Wolf("Wolf1", 1)
                    },
                    new List<Monster>
                    {
                        new Goblin("Goblin1", 2),
                        new Goblin("Goblin2", 2),
                        new Wolf("Wolf1", 2)
                    });

                // mountains
                AddStages(BiomeType.Mountains,
                    new List<Monster>
                    {
                        new Orc("Orc1", 4),
                        new Troll("Troll1", 3)
                    },
                    new List<Monster>
                    {
                        new Orc("Orc1", 5),
                        new Troll("Troll1", 4),
                        new Troll("Troll2", 3)
                    });

                var dragon = new Dragon("Dragon", 10, new Skill("Dragon Breath", 50));
                dragon.SpecialAttack.OnUse += targets =>
                {
                    foreach (var target in targets)
                    {
                        target.TakeDamage(dragon.Inteligence * 2);
                    }
                };

                biomes[BiomeType.Cave].Monsters.Add(new List<Monster>() { dragon });
            }
            else if (difficulty == Difficulty.Medium)
            {
                AddStages(BiomeType.Forest,
                    new List<Monster>
                    {
                        new Goblin("Goblin1", 1),
                        new Goblin("Goblin2", 2),
                        new Wolf("Wolf1", 1)
                    },
                    new List<Monster>
                    {
                        new Goblin("Goblin1", 3),
                        new Goblin("Goblin2", 3),
                        new Wolf("Wolf1", 2)
                    });

                AddStages(BiomeType.Mountains,
                    new List<Monster>
                    {
                        new Orc("Orc1", 4),
                        new Orc("Orc2", 3),
                        new Troll("Troll1", 3)
                    },
                    new List<Monster>
                    {
                        new Orc("Orc1", 5),
                        new Troll("Troll1", 5),
                        new Troll("Troll2", 4)
                    });

                var dragon = new Dragon("Dragon", 12, new Skill("Dragon Breath", 50));
                dragon.SpecialAttack.OnUse += targets =>
                {
                    foreach (var c in targets)
                    {
                        c.TakeDamage((int)(dragon.Inteligence * 2.2));
                    }
                };

                biomes[BiomeType.Cave].Monsters.Add(new List<Monster> { dragon });
            }
            else if (difficulty == Difficulty.Hard)
            {
                // forest
                AddStages(BiomeType.Forest,
                    new List<Monster>
                    {
                        new Goblin("Goblin1", 2),
                        new Goblin("Goblin2", 1),
                        new Wolf("Wolf1", 2),
                        new Wolf("Wolf2", 1)
                    },
                    new List<Monster>
                        {
                        new Goblin("Goblin1", 4),
                        new Goblin("Goblin2", 3),
                        new Wolf("Wolf1", 3)
                    });

                // mountains
                AddStages(BiomeType.Mountains,
                    new List<Monster>
                    {
                        new Orc("Orc1", 4),
                        new Troll("Troll1", 4),
                        new Troll("Troll2", 3)
                    },
                    new List<Monster>
                    {
                        new Orc("Orc1", 6),
                        new Troll("Troll1", 5),
                        new Troll("Troll2", 5)
                    });

                // cave (boss)
                var dragon = new Dragon("Dragon", 15, new Skill("Dragon Breath", 50));
                dragon.SpecialAttack.OnUse += targets =>
                {
                    foreach (var c in targets)
                    {
                        c.TakeDamage((int)(dragon.Inteligence * 2.5));
                    }
                };

                biomes[BiomeType.Cave].Monsters.Add(new List<Monster> { dragon });
            }

            StartGame();
        }

        private void StartGame()
        {
            SwapPanels(gamePanel, diffPanel);

            UpdateCharacterList();
        }

        private void characterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            statsPanel.Controls.Clear();

            if (characterList.SelectedIndex == -1)
            {
                return;
            }

            Character? selected = characterList.Items[characterList.SelectedIndex] as Character;
            if (selected != null)
            {
                string[] statSplit = selected.ToString().Split('\n');

                int y = 10;
                foreach (string stat in statSplit)
                {
                    AddNewLabel(stat, 8, new Point(15, y), statsPanel);

                    y += 20;
                }
            }
        }

        private void biomePanel_Click(object sender, EventArgs e)
        {
            Control? clicked = sender as Control;
            if (clicked == null)
            {
                return;
            }

            Panel biomePanel = GetTaggedPanel(clicked);

            string? tagStr = biomePanel.Tag?.ToString();
            if (tagStr == null || !tagStr.StartsWith("biome:"))
                return;

            string[] tagSplit = tagStr.Split(':');
            string tagValue = tagSplit[1];
            if (tagValue == "forest")
            {
                selectedBiome = BiomeType.Forest;
            }
            else if (tagValue == "mountains")
            {
                selectedBiome = BiomeType.Mountains;
            }
            else if (tagValue == "cave")
            {
                selectedBiome = BiomeType.Cave;
            }
            else
            {
                selectedBiome = null;
                MessageBox.Show("Unknown biome selected");
            }

            UpdateBiomeDescription();
        }

        private void travelBtn_Click(object sender, EventArgs e)
        {
            if(selectedBiome == null)
            {
                MessageBox.Show("Select a biome to travel to.");
                return;
            }

            Biome biome = biomes[selectedBiome.Value];

            TravelTo(biome);
        }


        // Fight Panel
        private void TravelTo(Biome biome)
        {
            SwapPanels(fightPanel, gamePanel);
        }
    }
}
