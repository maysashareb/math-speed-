using System;
using System.Drawing;

namespace WinFormsApp1
{
    partial class MathGameForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNum1;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.Label lblNum2;
        private System.Windows.Forms.Label lblEquals;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.PictureBox spritePictureBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNum1 = new System.Windows.Forms.Label();
            this.lblOperator = new System.Windows.Forms.Label();
            this.lblNum2 = new System.Windows.Forms.Label();
            this.lblEquals = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.homebt = new System.Windows.Forms.PictureBox();
            this.spritePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.homebt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spritePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNum1
            // 
            this.lblNum1.AutoSize = true;
            this.lblNum1.BackColor = System.Drawing.Color.Transparent;
            this.lblNum1.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold);
            this.lblNum1.ForeColor = System.Drawing.Color.Orange;
            this.lblNum1.Location = new System.Drawing.Point(71, 100);
            this.lblNum1.Name = "lblNum1";
            this.lblNum1.Size = new System.Drawing.Size(163, 59);
            this.lblNum1.TabIndex = 1;
            this.lblNum1.Text = "Num1";
            this.lblNum1.Paint += new System.Windows.Forms.PaintEventHandler(this.Label_Paint);
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.BackColor = System.Drawing.Color.Transparent;
            this.lblOperator.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold);
            this.lblOperator.ForeColor = System.Drawing.Color.Orange;
            this.lblOperator.Location = new System.Drawing.Point(157, 100);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(54, 59);
            this.lblOperator.TabIndex = 2;
            this.lblOperator.Text = "+";
            this.lblOperator.Paint += new System.Windows.Forms.PaintEventHandler(this.Label_Paint);
            // 
            // lblNum2
            // 
            this.lblNum2.AutoSize = true;
            this.lblNum2.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold);
            this.lblNum2.ForeColor = System.Drawing.Color.Orange;
            this.lblNum2.Location = new System.Drawing.Point(230, 100);
            this.lblNum2.Name = "lblNum2";
            this.lblNum2.Size = new System.Drawing.Size(163, 59);
            this.lblNum2.TabIndex = 3;
            this.lblNum2.Text = "Num2";
            this.lblNum2.Paint += new System.Windows.Forms.PaintEventHandler(this.Label_Paint);
            // 
            // lblEquals
            // 
            this.lblEquals.AutoSize = true;
            this.lblEquals.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold);
            this.lblEquals.ForeColor = System.Drawing.Color.Orange;
            this.lblEquals.Location = new System.Drawing.Point(339, 100);
            this.lblEquals.Name = "lblEquals";
            this.lblEquals.Size = new System.Drawing.Size(54, 59);
            this.lblEquals.TabIndex = 4;
            this.lblEquals.Text = "=";
            this.lblEquals.Click += new System.EventHandler(this.lblEquals_Click);
            this.lblEquals.Paint += new System.Windows.Forms.PaintEventHandler(this.Label_Paint);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.White;
            this.lblTime.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblTime.ForeColor = System.Drawing.Color.Black;
            this.lblTime.Location = new System.Drawing.Point(243, 9);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(93, 35);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "Time:";
            this.lblTime.Paint += new System.Windows.Forms.PaintEventHandler(this.Label_Paint);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.White;
            this.lblScore.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblScore.ForeColor = System.Drawing.Color.Black;
            this.lblScore.Location = new System.Drawing.Point(452, 9);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(109, 35);
            this.lblScore.TabIndex = 6;
            this.lblScore.Text = "Score:";
            this.lblScore.Paint += new System.Windows.Forms.PaintEventHandler(this.Label_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Orange;
            this.button1.Location = new System.Drawing.Point(606, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 80);
            this.button1.TabIndex = 8;
            this.button1.Text = "Option1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.AnswerButton_Click);
            this.button1.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.Orange;
            this.button2.Location = new System.Drawing.Point(692, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 80);
            this.button2.TabIndex = 9;
            this.button2.Text = "Option2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.AnswerButton_Click);
            this.button2.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.Orange;
            this.button3.Location = new System.Drawing.Point(606, 158);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 80);
            this.button3.TabIndex = 10;
            this.button3.Text = "Option3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.AnswerButton_Click);
            this.button3.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.Orange;
            this.button4.Location = new System.Drawing.Point(692, 158);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 80);
            this.button4.TabIndex = 11;
            this.button4.Text = "Option4";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.AnswerButton_Click);
            this.button4.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            // 
            // homebt
            // 
            this.homebt.BackColor = System.Drawing.Color.White;
            this.homebt.Image = global::WinFrormsApp1.Properties.Resources.icons8_home_50;
            this.homebt.Location = new System.Drawing.Point(758, 9);
            this.homebt.Name = "homebt";
            this.homebt.Size = new System.Drawing.Size(30, 32);
            this.homebt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.homebt.TabIndex = 13;
            this.homebt.TabStop = false;
            this.homebt.Click += new System.EventHandler(this.homebt_Click);
            this.homebt.Paint += new System.Windows.Forms.PaintEventHandler(this.Homebt_Paint);
            // 
            // spritePictureBox
            // 
            this.spritePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.spritePictureBox.Location = new System.Drawing.Point(33, 265);
            this.spritePictureBox.Name = "spritePictureBox";
            this.spritePictureBox.Size = new System.Drawing.Size(66, 67);
            this.spritePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.spritePictureBox.TabIndex = 7;
            this.spritePictureBox.TabStop = false;
            this.spritePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.Homebt_Paint);

            // 
            // MathGameForm
            // 
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.homebt);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.spritePictureBox);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblEquals);
            this.Controls.Add(this.lblNum2);
            this.Controls.Add(this.lblOperator);
            this.Controls.Add(this.lblNum1);
            this.DoubleBuffered = true;
            this.Name = "MathGameForm";
            this.Text = "Math Game";
            ((System.ComponentModel.ISupportInitialize)(this.homebt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spritePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.PictureBox homebt;
    }
}