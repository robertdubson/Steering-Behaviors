namespace HunterGame
{
    partial class Form1
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelTeam = new System.Windows.Forms.Label();
            this.numericUpDownWolves = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDoes = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHares = new System.Windows.Forms.NumericUpDown();
            this.labelWolves = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWolves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHares)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Modern No. 20", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.Yellow;
            this.labelTitle.Location = new System.Drawing.Point(201, 44);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(224, 65);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Hunter";
            // 
            // labelTeam
            // 
            this.labelTeam.AutoSize = true;
            this.labelTeam.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeam.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.labelTeam.Location = new System.Drawing.Point(218, 125);
            this.labelTeam.Name = "labelTeam";
            this.labelTeam.Size = new System.Drawing.Size(188, 25);
            this.labelTeam.TabIndex = 1;
            this.labelTeam.Text = "by Team Foxtrot";
            // 
            // numericUpDownWolves
            // 
            this.numericUpDownWolves.Location = new System.Drawing.Point(461, 184);
            this.numericUpDownWolves.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownWolves.Name = "numericUpDownWolves";
            this.numericUpDownWolves.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownWolves.TabIndex = 2;
            // 
            // numericUpDownDoes
            // 
            this.numericUpDownDoes.Location = new System.Drawing.Point(461, 236);
            this.numericUpDownDoes.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownDoes.Name = "numericUpDownDoes";
            this.numericUpDownDoes.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownDoes.TabIndex = 3;
            // 
            // numericUpDownHares
            // 
            this.numericUpDownHares.Location = new System.Drawing.Point(461, 290);
            this.numericUpDownHares.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownHares.Name = "numericUpDownHares";
            this.numericUpDownHares.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownHares.TabIndex = 4;
            // 
            // labelWolves
            // 
            this.labelWolves.AutoSize = true;
            this.labelWolves.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWolves.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.labelWolves.Location = new System.Drawing.Point(390, 184);
            this.labelWolves.Name = "labelWolves";
            this.labelWolves.Size = new System.Drawing.Size(65, 18);
            this.labelWolves.TabIndex = 5;
            this.labelWolves.Text = "Wolves:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label1.Location = new System.Drawing.Point(401, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Deers:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label2.Location = new System.Drawing.Point(399, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Hares:";
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Yellow;
            this.buttonStart.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(212, 337);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(228, 48);
            this.buttonStart.TabIndex = 8;
            this.buttonStart.Text = "START";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(355, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 28);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Maroon;
            this.button2.ForeColor = System.Drawing.Color.LimeGreen;
            this.button2.Location = new System.Drawing.Point(355, 232);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 28);
            this.button2.TabIndex = 10;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.RosyBrown;
            this.button3.Location = new System.Drawing.Point(355, 286);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(29, 28);
            this.button3.TabIndex = 11;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(317, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Use \"W\" \"A\" \"S\"\"D\" or arrow keys to control the hunter.  ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(338, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Try to shoot an animal by clicking on any place on the field.  ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(311, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Bear in mind that the power of your shot depends on the ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "cursor\'s position.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(300, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "If you don\'t se all the animals, try to restart the game, ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 256);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(240, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "developers don\'t know how to fix that bug :)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(617, 408);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelWolves);
            this.Controls.Add(this.numericUpDownHares);
            this.Controls.Add(this.numericUpDownDoes);
            this.Controls.Add(this.numericUpDownWolves);
            this.Controls.Add(this.labelTeam);
            this.Controls.Add(this.labelTitle);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWolves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHares)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelTeam;
        private System.Windows.Forms.NumericUpDown numericUpDownWolves;
        private System.Windows.Forms.NumericUpDown numericUpDownDoes;
        private System.Windows.Forms.NumericUpDown numericUpDownHares;
        private System.Windows.Forms.Label labelWolves;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

