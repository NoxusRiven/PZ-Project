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
            diffPanel = new Panel();
            backBtn = new Button();
            hardBtn = new Button();
            mediumBtn = new Button();
            easyBtn = new Button();
            diffLbl = new Label();
            exitBtn = new Button();
            startBtn = new Button();
            gameNameLbl = new Label();
            gamePanel = new Panel();
            startPanel.SuspendLayout();
            diffPanel.SuspendLayout();
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
            // diffPanel
            // 
            diffPanel.Controls.Add(backBtn);
            diffPanel.Controls.Add(hardBtn);
            diffPanel.Controls.Add(mediumBtn);
            diffPanel.Controls.Add(easyBtn);
            diffPanel.Controls.Add(diffLbl);
            diffPanel.Location = new Point(0, 0);
            diffPanel.Name = "diffPanel";
            diffPanel.Size = new Size(1099, 618);
            diffPanel.TabIndex = 3;
            diffPanel.Visible = false;
            // 
            // gamePanel
            // 
            gamePanel.Location = new Point(29, 42);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(250, 125);
            gamePanel.TabIndex = 5;
            gamePanel.Visible = false;

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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1099, 618);
            Controls.Add(startPanel);
            Controls.Add(diffPanel);
            Controls.Add(gamePanel);
            Name = "Form1";
            Text = "Mini RPG";
            startPanel.ResumeLayout(false);
            startPanel.PerformLayout();
            diffPanel.ResumeLayout(false);
            diffPanel.PerformLayout();
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
    }
}
