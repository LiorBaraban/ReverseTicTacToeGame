namespace ReverseTicTacToe.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelPlayer1State = new System.Windows.Forms.Label();
            this.labelPlayer2State = new System.Windows.Forms.Label();
            this.panelScores = new System.Windows.Forms.Panel();
            this.panelGameButtons = new System.Windows.Forms.Panel();
            this.panelScores.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPlayer1State
            // 
            this.labelPlayer1State.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlayer1State.AutoSize = true;
            this.labelPlayer1State.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPlayer1State.Location = new System.Drawing.Point(113, 3);
            this.labelPlayer1State.Name = "labelPlayer1State";
            this.labelPlayer1State.Size = new System.Drawing.Size(129, 39);
            this.labelPlayer1State.TabIndex = 12;
            this.labelPlayer1State.Text = "player1";
            // 
            // labelPlayer2State
            // 
            this.labelPlayer2State.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlayer2State.AutoSize = true;
            this.labelPlayer2State.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPlayer2State.Location = new System.Drawing.Point(248, 3);
            this.labelPlayer2State.Name = "labelPlayer2State";
            this.labelPlayer2State.Size = new System.Drawing.Size(129, 39);
            this.labelPlayer2State.TabIndex = 14;
            this.labelPlayer2State.Text = "player2";
            // 
            // panelScores
            // 
            this.panelScores.Controls.Add(this.labelPlayer2State);
            this.panelScores.Controls.Add(this.labelPlayer1State);
            this.panelScores.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.panelScores.Location = new System.Drawing.Point(0, 526);
            this.panelScores.Name = "panelScores";
            this.panelScores.Size = new System.Drawing.Size(541, 31);
            this.panelScores.TabIndex = 17;
            // 
            // panelGameButtons
            // 
            this.panelGameButtons.AutoSize = true;
            this.panelGameButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelGameButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGameButtons.Location = new System.Drawing.Point(0, 0);
            this.panelGameButtons.Name = "panelGameButtons";
            this.panelGameButtons.Size = new System.Drawing.Size(541, 526);
            this.panelGameButtons.TabIndex = 16;
            this.panelGameButtons.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGameButtons_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(541, 557);
            this.Controls.Add(this.panelGameButtons);
            this.Controls.Add(this.panelScores);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MinimumSize = new System.Drawing.Size(220, 252);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.panelScores.ResumeLayout(false);
            this.panelScores.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelPlayer1State;
        private System.Windows.Forms.Label labelPlayer2State;
        private System.Windows.Forms.Panel panelScores;
        private System.Windows.Forms.Panel panelGameButtons;
    }
}