namespace MiniWindowGame
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            startPanel = new Panel();
            exitBtn = new Button();
            startBtn = new Button();
            gameNameLbl = new Label();
            diffPanel = new Panel();
            backBtn = new Button();
            hardBtn = new Button();
            mediumBtn = new Button();
            easyBtn = new Button();
            diffLbl = new Label();
            gamePanel = new Panel();
            mapPanel = new Panel();
            cavePanel = new Panel();
            caveLbl = new Label();
            mountainsPanel = new Panel();
            moutainsLbl = new Label();
            forestPanel = new Panel();
            forestLbl = new Label();
            mapLbl = new Label();
            partyPanel = new Panel();
            statsPanel = new Panel();
            characterList = new ListBox();
            partyLbl = new Label();
            biomeDescPanel = new Panel();
            travelBtn = new Button();
            startPanel.SuspendLayout();
            diffPanel.SuspendLayout();
            gamePanel.SuspendLayout();
            mapPanel.SuspendLayout();
            cavePanel.SuspendLayout();
            mountainsPanel.SuspendLayout();
            forestPanel.SuspendLayout();
            partyPanel.SuspendLayout();
            SuspendLayout();
            // 
            // startPanel
            // 
            startPanel.Controls.Add(exitBtn);
            startPanel.Controls.Add(startBtn);
            startPanel.Controls.Add(gameNameLbl);
            startPanel.Dock = DockStyle.Fill;
            startPanel.Location = new Point(0, 0);
            startPanel.Name = "startPanel";
            startPanel.Size = new Size(1099, 618);
            startPanel.TabIndex = 0;
            // 
            // exitBtn
            // 
            exitBtn.Location = new Point(407, 416);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(302, 65);
            exitBtn.TabIndex = 2;
            exitBtn.Text = "Exit";
            exitBtn.UseVisualStyleBackColor = true;
            exitBtn.Click += exitBtn_Click;
            // 
            // startBtn
            // 
            startBtn.Font = new Font("Segoe UI", 9F);
            startBtn.Location = new Point(407, 224);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(302, 65);
            startBtn.TabIndex = 1;
            startBtn.Text = "Start";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += startBtn_Click;
            // 
            // gameNameLbl
            // 
            gameNameLbl.AutoSize = true;
            gameNameLbl.Font = new Font("Segoe UI", 30F);
            gameNameLbl.Location = new Point(435, 55);
            gameNameLbl.Name = "gameNameLbl";
            gameNameLbl.Size = new Size(232, 67);
            gameNameLbl.TabIndex = 0;
            gameNameLbl.Text = "Mini RPG";
            // 
            // diffPanel
            // 
            diffPanel.Controls.Add(backBtn);
            diffPanel.Controls.Add(hardBtn);
            diffPanel.Controls.Add(mediumBtn);
            diffPanel.Controls.Add(easyBtn);
            diffPanel.Controls.Add(diffLbl);
            diffPanel.Dock = DockStyle.Fill;
            diffPanel.Location = new Point(0, 0);
            diffPanel.Name = "diffPanel";
            diffPanel.Size = new Size(1099, 618);
            diffPanel.TabIndex = 3;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(376, 530);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(302, 65);
            backBtn.TabIndex = 4;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // hardBtn
            // 
            hardBtn.Location = new Point(376, 379);
            hardBtn.Name = "hardBtn";
            hardBtn.Size = new Size(302, 65);
            hardBtn.TabIndex = 3;
            hardBtn.Text = "Hard";
            hardBtn.UseVisualStyleBackColor = true;
            hardBtn.Click += hardBtn_Click;
            // 
            // mediumBtn
            // 
            mediumBtn.Location = new Point(376, 273);
            mediumBtn.Name = "mediumBtn";
            mediumBtn.Size = new Size(302, 65);
            mediumBtn.TabIndex = 2;
            mediumBtn.Text = "Medium";
            mediumBtn.UseVisualStyleBackColor = true;
            mediumBtn.Click += mediumBtn_Click;
            // 
            // easyBtn
            // 
            easyBtn.Location = new Point(376, 177);
            easyBtn.Name = "easyBtn";
            easyBtn.Size = new Size(302, 65);
            easyBtn.TabIndex = 1;
            easyBtn.Text = "Easy";
            easyBtn.UseVisualStyleBackColor = true;
            easyBtn.Click += easyBtn_Click;
            // 
            // diffLbl
            // 
            diffLbl.AutoSize = true;
            diffLbl.Font = new Font("Segoe UI", 30F);
            diffLbl.Location = new Point(342, 64);
            diffLbl.Name = "diffLbl";
            diffLbl.Size = new Size(402, 67);
            diffLbl.TabIndex = 0;
            diffLbl.Text = "Choose Difficulty";
            // 
            // gamePanel
            // 
            gamePanel.Controls.Add(mapPanel);
            gamePanel.Controls.Add(partyPanel);
            gamePanel.Dock = DockStyle.Fill;
            gamePanel.Location = new Point(0, 0);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(1099, 618);
            gamePanel.TabIndex = 5;
            // 
            // mapPanel
            // 
            mapPanel.BackColor = Color.FromArgb(123, 186, 140);
            mapPanel.Controls.Add(travelBtn);
            mapPanel.Controls.Add(biomeDescPanel);
            mapPanel.Controls.Add(cavePanel);
            mapPanel.Controls.Add(mountainsPanel);
            mapPanel.Controls.Add(forestPanel);
            mapPanel.Controls.Add(mapLbl);
            mapPanel.Font = new Font("Microsoft Sans Serif", 8.25F);
            mapPanel.Location = new Point(326, 25);
            mapPanel.Name = "mapPanel";
            mapPanel.Size = new Size(752, 570);
            mapPanel.TabIndex = 3;
            // 
            // cavePanel
            // 
            cavePanel.BackColor = Color.Gray;
            cavePanel.Controls.Add(caveLbl);
            cavePanel.Font = new Font("Microsoft Sans Serif", 15F);
            cavePanel.Location = new Point(536, 100);
            cavePanel.Name = "cavePanel";
            cavePanel.Size = new Size(176, 76);
            cavePanel.TabIndex = 4;
            // 
            // caveLbl
            // 
            caveLbl.AutoSize = true;
            caveLbl.Location = new Point(50, 24);
            caveLbl.Name = "caveLbl";
            caveLbl.Size = new Size(72, 29);
            caveLbl.TabIndex = 0;
            caveLbl.Text = "Cave";
            // 
            // mountainsPanel
            // 
            mountainsPanel.BackColor = Color.FromArgb(161, 157, 138);
            mountainsPanel.Controls.Add(moutainsLbl);
            mountainsPanel.Location = new Point(311, 100);
            mountainsPanel.Name = "mountainsPanel";
            mountainsPanel.Size = new Size(162, 76);
            mountainsPanel.TabIndex = 3;
            // 
            // moutainsLbl
            // 
            moutainsLbl.AutoSize = true;
            moutainsLbl.Font = new Font("Microsoft Sans Serif", 15F);
            moutainsLbl.Location = new Point(21, 22);
            moutainsLbl.Name = "moutainsLbl";
            moutainsLbl.Size = new Size(130, 29);
            moutainsLbl.TabIndex = 0;
            moutainsLbl.Text = "Mountains";
            // 
            // forestPanel
            // 
            forestPanel.BackColor = Color.FromArgb(45, 115, 64);
            forestPanel.Controls.Add(forestLbl);
            forestPanel.Location = new Point(81, 100);
            forestPanel.Name = "forestPanel";
            forestPanel.Size = new Size(155, 76);
            forestPanel.TabIndex = 2;
            // 
            // forestLbl
            // 
            forestLbl.AutoSize = true;
            forestLbl.Font = new Font("Segoe UI", 15F);
            forestLbl.Location = new Point(37, 18);
            forestLbl.Name = "forestLbl";
            forestLbl.Size = new Size(83, 35);
            forestLbl.TabIndex = 0;
            forestLbl.Text = "Forest";
            // 
            // mapLbl
            // 
            mapLbl.AutoSize = true;
            mapLbl.Font = new Font("Microsoft Sans Serif", 25F);
            mapLbl.Location = new Point(347, 19);
            mapLbl.Name = "mapLbl";
            mapLbl.Size = new Size(101, 48);
            mapLbl.TabIndex = 1;
            mapLbl.Text = "Map";
            // 
            // partyPanel
            // 
            partyPanel.BackColor = Color.FromArgb(200, 200, 200);
            partyPanel.Controls.Add(statsPanel);
            partyPanel.Controls.Add(characterList);
            partyPanel.Controls.Add(partyLbl);
            partyPanel.Location = new Point(26, 25);
            partyPanel.Name = "partyPanel";
            partyPanel.Size = new Size(279, 570);
            partyPanel.TabIndex = 2;
            // 
            // statsPanel
            // 
            statsPanel.BackColor = Color.White;
            statsPanel.Location = new Point(23, 291);
            statsPanel.Name = "statsPanel";
            statsPanel.Size = new Size(229, 255);
            statsPanel.TabIndex = 3;
            // 
            // characterList
            // 
            characterList.FormattingEnabled = true;
            characterList.Location = new Point(23, 60);
            characterList.Name = "characterList";
            characterList.Size = new Size(229, 204);
            characterList.TabIndex = 2;
            // 
            // partyLbl
            // 
            partyLbl.AutoSize = true;
            partyLbl.Font = new Font("Segoe UI", 20F);
            partyLbl.Location = new Point(87, 3);
            partyLbl.Name = "partyLbl";
            partyLbl.Size = new Size(95, 46);
            partyLbl.TabIndex = 0;
            partyLbl.Text = "Party";
            // 
            // biomeDescPanel
            // 
            biomeDescPanel.BackColor = Color.White;
            biomeDescPanel.Location = new Point(109, 252);
            biomeDescPanel.Name = "biomeDescPanel";
            biomeDescPanel.Size = new Size(566, 204);
            biomeDescPanel.TabIndex = 5;
            // 
            // travelBtn
            // 
            travelBtn.Location = new Point(347, 505);
            travelBtn.Name = "travelBtn";
            travelBtn.Size = new Size(94, 29);
            travelBtn.TabIndex = 6;
            travelBtn.Text = "Travel";
            travelBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1099, 618);
            Controls.Add(gamePanel);
            Controls.Add(startPanel);
            Controls.Add(diffPanel);
            Name = "Form1";
            Text = "Mini RPG";
            startPanel.ResumeLayout(false);
            startPanel.PerformLayout();
            diffPanel.ResumeLayout(false);
            diffPanel.PerformLayout();
            gamePanel.ResumeLayout(false);
            mapPanel.ResumeLayout(false);
            mapPanel.PerformLayout();
            cavePanel.ResumeLayout(false);
            cavePanel.PerformLayout();
            mountainsPanel.ResumeLayout(false);
            mountainsPanel.PerformLayout();
            forestPanel.ResumeLayout(false);
            forestPanel.PerformLayout();
            partyPanel.ResumeLayout(false);
            partyPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        void SwapPanels(Panel toShow, Panel toHide)
        {
            toShow.Visible = true;
            toHide.Visible = false;
        }

        private Panel startPanel;
        private Button exitBtn;
        private Button startBtn;
        private Label gameNameLbl;
        private Panel diffPanel;
        private Label diffLbl;
        private Button backBtn;
        private Button hardBtn;
        private Button mediumBtn;
        private Button easyBtn;
        private Panel gamePanel;
        private Label partyLbl;
        private Label mapLbl;
        private Panel partyPanel;
        private Panel mapPanel;
        private ListBox characterList;
        private Panel statsPanel;
        private Panel forestPanel;
        private Label forestLbl;
        private Panel mountainsPanel;
        private Label moutainsLbl;
        private Panel cavePanel;
        private Label caveLbl;
        private Button travelBtn;
        private Panel biomeDescPanel;
    }
}
