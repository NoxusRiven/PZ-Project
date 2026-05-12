using MiniWindowGameLib.Character;
using MiniWindowGameLib.Core;
using MiniWindowGameLib.Enemy;
using System.DirectoryServices.ActiveDirectory;
using System.Text.Json;
using System.Threading.Tasks.Sources;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace MiniWindowGame
{
    
    public partial class Form1 : Form
    {
        List<Character> characters;

        Difficulty currentDifficulty;

        Dictionary<BiomeType, Biome> biomes;

        BiomeType? selectedBiome;
        Biome currentBiome;
        bool continuneExploring;

        // ask if those fields could be moved down
        Character selectedChar;
        Monster selectedEnemy;
        bool isAttacking;
        Skill selectedSkill;

        List<TurnAction> charactersTurn;

        int totalGoldEarned;
        int totalExpEarned;

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
            actionPanel.Visible = false;


            characters = new List<Character>();
            biomes = new Dictionary<BiomeType, Biome>();

            charactersTurn = new();

            totalExpEarned = 0;
            totalGoldEarned = 0;

            selectedBiome = null;
            currentBiome = null;
            continuneExploring = false;

            selectedChar = null;
            selectedSkill = null;
            selectedEnemy = null;
            isAttacking = false;

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

        private void UpdateFightCharacterList()
        {
            fightCharacterList.Items.Clear();

            foreach (var c in characters)
            {
                fightCharacterList.Items.Add(c);
            }
            fightCharacterList.DisplayMember = "Name";

            fightCharacterList.Refresh();
        }

        private void UpdateSkillList(Character c)
        {
            skillList.Items.Clear();

            foreach (var skill in c.SkillList)
            {
                skillList.Items.Add(skill);
            }
            skillList.DisplayMember = "Name";
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

        private void loadSaveBtn_Click(object sender, EventArgs e)
        {
            SaveState? save = SaveState.Load("save.json");

            if (save == null)
            {
                MessageBox.Show("Save not found.");
                return;
            }

            foreach (var c in save.Characters)
            {
                c.InitSkills();
            }

            InitGame(save.Difficulty, save.Characters);

            UpdateCharacterList();

            MessageBox.Show("Game loaded.");
        }


        // Difficulty Panel
        private void easyBtn_Click(object sender, EventArgs e)
        {
            currentDifficulty = Difficulty.Easy;
            InitGame(currentDifficulty);
        }

        private void mediumBtn_Click(object sender, EventArgs e)
        {
            currentDifficulty = Difficulty.Medium;
            InitGame(currentDifficulty);
        }

        private void hardBtn_Click(object sender, EventArgs e)
        {
            currentDifficulty = Difficulty.Hard;
            InitGame(currentDifficulty);
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
            List<Character> newCharacters = new List<Character>();
            newCharacters.Add(new Warrior("Leonidas"));
            newCharacters.Add(new Archer("Hicky"));
            newCharacters.Add(new Mage("Merlin"));

            InitGame(difficulty, newCharacters);   
        }

        private void InitGame(Difficulty difficulty, List<Character> characters)
        {
            this.characters = characters;

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
                return;


            Panel? biomePanel = GetTaggedRoot(clicked) as Panel ?? null;
            if (biomePanel == null)
                return;


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
            if (selectedBiome == null)
            {
                MessageBox.Show("Select a biome to travel to.");
                return;
            }

            currentBiome = biomes[selectedBiome.Value];

            TravelTo();
        }


        // Fight Panel
        private void TravelTo()
        {
            SwapPanels(fightPanel, gamePanel);

            StartFight();
        }

        private void StartFight()
        {
            UpdateFightCharacterList();

            RenderEnemiesCentered(enemyPanel, currentBiome.Monsters.First());
        }

        private void RenderEnemiesCentered(Panel container, List<Monster> enemies)
        {
            container.Controls.Clear();

            if (enemies == null || enemies.Count == 0)
                return;

            int panelWidth = 250;
            int panelHeight = 60;
            int spacing = 15;

            int totalHeight = enemies.Count * panelHeight + (enemies.Count - 1) * spacing;

            int startY = (container.Height - totalHeight) / 2;

            for (int i = 0; i < enemies.Count; i++)
            {
                Monster enemy = enemies[i];

                Panel enemyPanel = CreateEnemyPanel(enemy);
                enemyPanel.Width = panelWidth;
                enemyPanel.Height = panelHeight;

                int x = (container.Width - panelWidth) / 2;

                int y = startY + i * (panelHeight + spacing);

                enemyPanel.Location = new Point(x, y);

                enemyPanel.Tag = enemy;

                enemyPanel.Click += EnemyPanel_Click;

                container.Controls.Add(enemyPanel);
            }
        }

        private Panel CreateEnemyPanel(Monster enemy)
        {
            Panel p = new Panel();

            bool dead = !enemy.IsAlive;

            p.BackColor = dead
                ? Color.FromArgb(60, 40, 40)
                : Color.FromArgb(20, 20, 40);

            Label name = new Label();

            name.Text = $"{enemy.Name} (Lv {enemy.Level})";

            name.ForeColor = dead
                ? Color.FromArgb(220, 120, 120)
                : Color.White;

            name.Location = new Point(10, 5);
            name.AutoSize = true;

            ProgressBar hp = new ProgressBar();

            hp.Width = 200;
            hp.Height = 12;
            hp.Location = new Point(10, 30);

            hp.Maximum = enemy.MaxHp;

            hp.Value = Math.Max(0, enemy.CurrentHp);

            hp.Tag = enemy;

            p.Controls.Add(name);
            p.Controls.Add(hp);

            return p;
        }

        private void UpdateEnemyHP()
        {
            int currentStage = continuneExploring ? 1 : 0;
            foreach (var enemy in currentBiome.Monsters[currentStage])
            {
                foreach (Control ctrl in enemyPanel.Controls)
                {
                    Panel p = ctrl as Panel;
                    if (p == null) continue;

                    if (p.Tag == enemy)
                    {
                        ProgressBar? hp = p.Controls
                            .OfType<ProgressBar>()
                            .FirstOrDefault();

                        if (hp != null)
                        {
                            hp.Value = enemy.CurrentHp;
                        }
                    }
                }
            }
        }

        private void EnemyPanel_Click(object sender, EventArgs e)
        {
            Panel? p = sender as Panel;

            if (p == null)
                return;

            Monster? enemy = p.Tag as Monster;

            if (enemy == null)
                return;

            if (enemy.CurrentHp <= 0)
                return;

            selectedEnemy = enemy;

            MarkCharacterAsReady();

            fightCharacterList.Refresh();
        }

        private void RefreshEnemies()
        {
            int currentStage = continuneExploring ? 1 : 0;

            RenderEnemiesCentered(
                enemyPanel,
                currentBiome.Monsters[currentStage]
            );
        }

        private void MarkCharacterAsReady()
        {
            TurnAction turn = new TurnAction
            {
                Character = selectedChar,
                Target = selectedEnemy,
                Skill = selectedSkill,
                IsAttack = isAttacking
            };

            charactersTurn.Add(turn);
        }

        private void fightCharacterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            infoPanel.Controls.Clear();

            skillPanel.Visible = false;
            actionPanel.BringToFront();

            int idx = fightCharacterList.SelectedIndex;
            if (idx != -1)
            {
                Character? selected = fightCharacterList.Items[idx] as Character;

                if (selected == null)
                    return;

                if (!selected.IsAlive)
                    return;

                selectedChar = selected;

                int padding = 18;
                int y = 10;
                int fontSize = 10;
                AddNewLabel($"{selected.Name} - {selected.Level}", fontSize, new Point(15, y), infoPanel);
                y += padding;
                AddNewLabel($"HP: {selected.CurrentHp}/{selected.MaxHp}", fontSize, new Point(15, y), infoPanel);
                y += padding;
                if (selected is Mage)
                {
                    Mage mage = selected as Mage;
                    AddNewLabel($"Mana: {mage.CurrentMana}/{mage.MaxMana}", fontSize, new Point(15, y), infoPanel);
                    y += padding;
                }
                else if (selected is Archer)
                {
                    Archer archer = selected as Archer;
                    AddNewLabel($"Skills usage left: {archer.SkillUsageCount}/{archer.SkillsLeft}", fontSize, new Point(15, y), infoPanel);
                    y += padding;
                }
                AddNewLabel($"Damage : {selected.Damage}", fontSize, new Point(15, y), infoPanel);

                actionPanel.Visible = true;
            }
        }

        private void fightCharacterList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var list = sender as ListBox;
            Character c = list.Items[e.Index] as Character;
            if (c == null) return;

            e.DrawBackground();

            Color bgColor;

            if (charactersTurn.Any(q => q.Character == c))
            {
                bgColor = Color.FromArgb(75, 215, 175);
            }
            else if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                bgColor = Color.FromArgb(150, 225, 240);
            }
            else
            {
                bgColor = Color.White;
            }

            using (Brush bgBrush = new SolidBrush(bgColor))
            {
                e.Graphics.FillRectangle(bgBrush, e.Bounds);
            }

            Brush textBrush = Brushes.Black;

            int x = e.Bounds.X + 5;
            int y = e.Bounds.Y + 5;

            e.Graphics.DrawString($"{c.Name} (Lv {c.Level})", e.Font, textBrush, x, y);

            y += 18;

            int barWidth = 120;
            int barHeight = 10;

            int hpWidth = (int)((double)c.CurrentHp / c.MaxHp * barWidth);

            Rectangle bg = new Rectangle(x, y, barWidth, barHeight);
            Rectangle hp = new Rectangle(x, y, hpWidth, barHeight);

            e.Graphics.FillRectangle(Brushes.DarkGray, bg);

            Brush hpBrush = Brushes.Green;
            double ratio = (double)c.CurrentHp / c.MaxHp;

            if (ratio < 0.3) hpBrush = Brushes.Red;
            else if (ratio < 0.6) hpBrush = Brushes.Orange;

            e.Graphics.FillRectangle(hpBrush, hp);

            e.DrawFocusRectangle();
        }

        private void attackBtn_Click(object sender, EventArgs e)
        {
            isAttacking = true;
            selectedSkill = null;
        }

        private void useSkillBtn_Click(object sender, EventArgs e)
        {
            if (fightCharacterList.SelectedIndex < 0)
                return;

            SwapPanels(skillPanel, actionPanel);


            Character? selected = fightCharacterList.SelectedItem as Character;
            UpdateSkillList(selected);
        }

        private void useItemBtn_Click(object sender, EventArgs e)
        {
            // TODO: show list of items (for now just 2 potion) 
        }

        private void fightBtn_Click(object sender, EventArgs e)
        {
            if (selectedChar == null)
            {
                MessageBox.Show("Select a character to fight.");
                return;
            }

            if (!isAttacking && selectedSkill == null)
            {
                MessageBox.Show("Select an action to perform.");
                return;
            }

            if (selectedEnemy == null)
            {
                MessageBox.Show("Select an enemy to attack.");
                return;
            }

            //if(charactersTurn.Count == 0)
            //{
            //    MessageBox.Show("At least one character need to be prepared");
            //    return;
            //}

            OneGameTurn();

            UpdateEnemyHP();

            RefreshEnemies();

            CheckFightState();

            fightCharacterList.Refresh();

            charactersTurn.Clear();

            selectedChar = null;
            selectedEnemy = null;
            selectedSkill = null;
            isAttacking = false;
        }

        private void OneGameTurn()
        {

            foreach (var turn in charactersTurn)
            {
                turn.Execute();
            }

            int currentStage = continuneExploring ? 1 : 0;

            List<Monster> enemies = currentBiome.Monsters[currentStage];

            Character? toAttack = characters
                .Where(c => c.IsAlive)
                .OrderBy(c => c.CurrentHp)
                .FirstOrDefault();

            if (toAttack == null)
            {
                MessageBox.Show("All characters are dead.");
                return;
            }

            foreach (var enemy in enemies)
            {
                toAttack.TakeDamage(enemy.Damage);
            }
        }

        private void skillList_SelectedIndexChanged(object sender, EventArgs e)
        {
            skillDescPanel.Controls.Clear();

            int index = skillList.SelectedIndex;

            if (index < 0)
                return;

            Skill? skill = skillList.Items[index] as Skill;

            selectedSkill = skill;
            isAttacking = false;

            AddNewLabel(skill.ToDisplay(), 8, new Point(10, 10), skillDescPanel);
        }

        private (int gold, int exp) CalculateRewards(List<Monster> enemies)
        {
            int gold = 0;
            int exp = 0;

            foreach (var enemy in enemies)
            {
                if (enemy.CurrentHp <= 0)
                {
                    gold += enemy.GoldReward;
                    exp += enemy.ExperienceReward;
                }
            }

            return (gold, exp);
        }

        private void CheckFightState()
        {
            bool allHeroesDead = characters.All(c => c.CurrentHp <= 0);

            int currentStage = continuneExploring ? 1 : 0;

            List<Monster> enemies = currentBiome.Monsters[currentStage];

            bool allEnemiesDead = enemies.All(e => e.CurrentHp <= 0);

            if (allHeroesDead)
            {
                HandleEnding(enemies, false);
                return;
            }

            if (allEnemiesDead)
            {
                HandleEnding(enemies, true);
            }
        }

        private void HandleEnding(List<Monster> enemies, bool won)
        {
            var rewards = CalculateRewards(enemies);
            totalGoldEarned += rewards.gold;
            totalExpEarned += rewards.exp;

            if (won)
            {

                if (continuneExploring)
                {
                    MessageBox.Show(
                        $"Victory!\n\n" +
                        $"Total gold earned: {totalGoldEarned}\n" +
                        $"Total exp earned: {totalExpEarned}\n\n" +
                        "Victory"
                    );
                    ReturnToBase();
                    return;

                }

                DialogResult result = MessageBox.Show(
                        $"Victory!\n\n" +
                        $"Gold earned: {rewards.gold}\n" +
                        $"Exp earned: {rewards.exp}\n\n" +
                        $"Continue exploring?",
                        "Victory",
                        MessageBoxButtons.YesNo
                    );

                if (result == DialogResult.Yes)
                {
                    continuneExploring = true;

                    RenderEnemiesCentered(enemyPanel, currentBiome.Monsters[1]);
                }
                else
                {
                    ReturnToBase();
                }
            }
            else
            {
                int lostGold = rewards.gold / 3;


                MessageBox.Show(
                    $"Your party was defeated!\n\n" +
                    $"Total exp earned: {totalExpEarned}\n" +
                    $"Total gold earned {totalGoldEarned} - pentalty {lostGold}",
                    "Defeat"
                );

                totalGoldEarned -= lostGold;


                ReturnToBase();
            }

        }

        private void ReturnToBase()
        {
            selectedEnemy = null;
            selectedChar = null;
            selectedSkill = null;

            isAttacking = false;

            charactersTurn.Clear();

            continuneExploring = false;

            foreach (var c in characters)
            {
                if (!c.IsAlive)
                    continue;
                
                c.Gold += totalGoldEarned;
                c.IncExp(totalExpEarned);

                if (c is Archer)
                {
                    Archer a = c as Archer;
                    a.SkillsLeft = a.SkillUsageCount;
                }
            }

            ReviveCharacters();

            totalGoldEarned = 0;
            totalExpEarned = 0;

            SwapPanels(gamePanel, fightPanel);

            UpdateCharacterList();
        }

        private void ReviveCharacters()
        {
            foreach (var c in characters)
            {
                c.CurrentHp = c.MaxHp;

                if (c is Mage)
                {
                    Mage m = c as Mage;
                    m.CurrentMana = m.MaxMana;
                }

                if (c is Archer)
                {
                    Archer a = c as Archer;
                    a.SkillsLeft = a.SkillUsageCount;
                }
            }
        }

        private void saveProgressBtn_Click(object sender, EventArgs e)
        {
            SaveState save = new SaveState(characters, currentDifficulty);
            save.Save("save.json");

            MessageBox.Show("Game state has been saved");
        }
    }

}
