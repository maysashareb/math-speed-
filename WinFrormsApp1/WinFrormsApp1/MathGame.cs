using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace WinFormsApp1
{
    public partial class MathGameForm : Form
    {
        private VlcControl vlcControl;
        private int correctAnswer;
        private int score = 0;
        private int questionCount = 0;
        private int totalQuestions = 15;
        private Timer timer = new Timer();
        private int timeLeft = 30;
        private Random random = new Random();
        private bool isButtonClicked = false;
        private int jumpHeight = 20;
        private int jumpSpeed = 2;
        private bool isJumping = false;
        private bool isGameActive = true; // Flag to control the game state

        private int jumpDirection = -1; // -1 for up, 1 for down
        private Timer moveTimer;
        private Timer jumpTimer;
        private int foxOriginalY;
       


        public MathGameForm()
        {
            InitializeComponent();
            InitializeVlcPlayer();
            timer.Interval = 1000; // 1 second intervals
            timer.Tick += Timer_Tick;
            timer.Start();
            GenerateQuestion();
            InitializeJumpTimer();
            SetTransparentFoxImage();
            //   InitializeBtnHome();
            InitializeHomePictureBox();

        }
        private void InitializeJumpTimer()
        {
            moveTimer = new Timer();
            moveTimer.Interval = 50; // Move the fox every 50 ms
            moveTimer.Tick += MoveTimer_Tick;
            moveTimer.Start();

            jumpTimer = new Timer();
            jumpTimer.Interval = 20; 
            jumpTimer.Tick += JumpTimer_Tick;
        }
        private void SetTransparentFoxImage()
        {
            try
            {
                // Set the fox image to spritePictureBox
                Bitmap foxBitmap = new Bitmap(@"C:\Users\maysa\source\repos\WinFrormsApp1\WinFrormsApp1\Resources\spiratimage1.png");
                var transparentFoxBitmap = MakeTransparent(foxBitmap, Color.White, 5);
                spritePictureBox.Image = transparentFoxBitmap;
                spritePictureBox.BackColor = Color.Transparent; // Ensure the picture box itself has no background
                spritePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while setting the fox image: {ex.Message}");
            }
        }
   

        private Bitmap MakeTransparent(Bitmap bitmap, Color color, int tolerance)
        {
            Bitmap transparentImage = new Bitmap(bitmap);

            for (int i = transparentImage.Size.Width - 1; i >= 0; i--)
            {
                for (int j = transparentImage.Size.Height - 1; j >= 0; j--)
                {
                    var currentColor = transparentImage.GetPixel(i, j);
                    if (Math.Abs(color.R - currentColor.R) < tolerance &&
                        Math.Abs(color.G - currentColor.G) < tolerance &&
                        Math.Abs(color.B - currentColor.B) < tolerance)
                    {
                        transparentImage.SetPixel(i, j, Color.Transparent);
                    }
                }
            }

            transparentImage.MakeTransparent(color);
            return transparentImage;
        }
        private void Homebt_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            int radius = 10; // Adjust the radius as needed
            GraphicsPath path = new GraphicsPath();

            Rectangle rect = pb.ClientRectangle;
            path.AddArc(rect.Left, rect.Top, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Top, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.Left, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();

            pb.Region = new Region(path);

            // Draw the image inside the rounded region
            e.Graphics.SetClip(path);
            e.Graphics.DrawImage(pb.Image, rect);
        }
        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            // Move the fox to the right
            spritePictureBox.Left += 5;
            if (spritePictureBox.Left > this.Width)
            {
                // Reset position
                spritePictureBox.Left = -spritePictureBox.Width;
            }
        }

        private void JumpTimer_Tick(object sender, EventArgs e)
        {
            if (isJumping)
            {
                // Simulate jump
                spritePictureBox.Top -= jumpHeight;
                jumpHeight -= 2; // Gravity effect
                if (jumpHeight <= -20) // Jump complete
                {
                    isJumping = false;
                    jumpTimer.Stop();
                    jumpHeight = 20; // Reset jump height
                    spritePictureBox.Top = foxOriginalY; // Reset position
                }
            }
        }

        private void InitializeVlcPlayer()
        {
            vlcControl = new VlcControl();
            vlcControl.Size = this.ClientSize; // Make it cover the entire form
            vlcControl.Location = new Point(0, 0);
            this.Controls.Add(vlcControl);
            vlcControl.SendToBack(); // Ensure it is behind other controls

            var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            var libDirectory = new DirectoryInfo(Path.Combine(currentDirectory.FullName, "libvlc", IntPtr.Size == 8 ? "win-x64" : "win-x86"));

            if (!libDirectory.Exists)
            {
                MessageBox.Show($"The VLC library directory {libDirectory.FullName} was not found.");
                return;
            }

            vlcControl.BeginInit();
            vlcControl.VlcLibDirectory = libDirectory;
            vlcControl.VlcMediaplayerOptions = new[] { "--no-video-title-show" };
            vlcControl.EndInit();

            try
            {
                string videoPath = @"C:\Users\maysa\Downloads\Game Background - Mountain Forest Parallax Side Scroller.mp4";
                if (File.Exists(videoPath))
                {
                    vlcControl.SetMedia(new Uri(videoPath));
                    vlcControl.Play();
                    vlcControl.EndReached += (sender, e) =>
                    {
                        vlcControl.Play();
                    };
                }
                else
                {
                    MessageBox.Show("The video file could not be found at the specified path.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while setting media: {ex.Message}");
            }
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            isButtonClicked = true;
            (sender as Button).Invalidate(); // Trigger a repaint
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            isButtonClicked = false;
            (sender as Button).Invalidate(); // Trigger a repaint
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!isGameActive) return;

            timeLeft--;
            lblTime.Text = "Time: " + timeLeft;
            if (timeLeft <= 0)
            {
                timer.Stop();
                isGameActive = false; // Set the game as inactive
                moveTimer.Stop();
                jumpTimer.Stop();
                MessageBox.Show("Time's up! Your score is: " + score);
                this.Close();
            }
        }
        private void Button_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                Graphics graphics = e.Graphics;
                Rectangle buttonRect = new Rectangle(0, 0, btn.Width, btn.Height);
                int borderRadius = 10;
                int borderWidth = 2;

                // Set the background color to white
                graphics.Clear(btn.BackColor);

                // Draw the shadow if the button is clicked
                if (isButtonClicked)
                {
                    Rectangle shadowRect = new Rectangle(buttonRect.Left + 3, buttonRect.Top + 3, buttonRect.Width, buttonRect.Height);
                    using (GraphicsPath shadowPath = new GraphicsPath())
                    {
                        shadowPath.AddArc(shadowRect.Left, shadowRect.Top, borderRadius, borderRadius, 180, 90);
                        shadowPath.AddArc(shadowRect.Right - borderRadius, shadowRect.Top, borderRadius, borderRadius, 270, 90);
                        shadowPath.AddArc(shadowRect.Right - borderRadius, shadowRect.Bottom - borderRadius, borderRadius, borderRadius, 0, 90);
                        shadowPath.AddArc(shadowRect.Left, shadowRect.Bottom - borderRadius, borderRadius, borderRadius, 90, 90);
                        shadowPath.CloseFigure();

                        using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(60, Color.Black)))
                        {
                            graphics.FillPath(shadowBrush, shadowPath);
                        }
                    }
                }

                // Draw the rounded rectangle border
                using (Pen borderPen = new Pen(Color.Orange, borderWidth))
                {
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        path.AddArc(buttonRect.Left, buttonRect.Top, borderRadius, borderRadius, 180, 90);
                        path.AddArc(buttonRect.Right - borderRadius, buttonRect.Top, borderRadius, borderRadius, 270, 90);
                        path.AddArc(buttonRect.Right - borderRadius, buttonRect.Bottom - borderRadius, borderRadius, borderRadius, 0, 90);
                        path.AddArc(buttonRect.Left, buttonRect.Bottom - borderRadius, borderRadius, borderRadius, 90, 90);
                        path.CloseFigure();

                        btn.Region = new Region(path);
                        graphics.DrawPath(borderPen, path);
                    }
                }

                // Draw the text
                TextRenderer.DrawText(graphics, btn.Text, btn.Font, buttonRect, btn.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void Label_Paint(object sender, PaintEventArgs e)
        {
            Label lbl = sender as Label;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw rounded rectangle for label
            Rectangle rect = new Rectangle(0, 0, lbl.Width, lbl.Height);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, 20, 20, 180, 90);
            path.AddArc(rect.X + rect.Width - 20, rect.Y, 20, 20, 270, 90);
            path.AddArc(rect.X + rect.Width - 20, rect.Y + rect.Height - 20, 20, 20, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - 20, 20, 20, 90, 90);
            path.CloseAllFigures();

            lbl.Region = new Region(path);

            // Fill background with transparent color
            e.Graphics.FillPath(Brushes.Transparent, path);

            // Draw the text
            TextRenderer.DrawText(e.Graphics, lbl.Text, lbl.Font, rect, lbl.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }


        private void GenerateQuestion()
        {
            int num1 = random.Next(1, 10);
            int num2 = random.Next(1, 10);
            string[] operators = { "+", "-" };
            string selectedOperator = operators[random.Next(operators.Length)];

            // Determine the correct answer based on the operator
            switch (selectedOperator)
            {
                case "+":
                    correctAnswer = num1 + num2;
                    break;
                case "-":
                    correctAnswer = num1 - num2;
                    break;
            }

            lblNum1.Text = num1.ToString();
            lblOperator.Text = selectedOperator;
            lblNum2.Text = num2.ToString();

            int correctButton = random.Next(1, 5);
            for (int i = 1; i <= 4; i++)
            {
                Button btn = this.Controls["button" + i] as Button;
                if (i == correctButton)
                {
                    btn.Text = correctAnswer.ToString();
                }
                else
                {
                    int wrongAnswer;
                    do
                    {
                        wrongAnswer = random.Next(1, 20);
                    } while (wrongAnswer == correctAnswer); // Ensure no duplicates
                    btn.Text = wrongAnswer.ToString();
                }
            }
        }


       private void InitializeHomePictureBox()
        {
            this.homebt = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.homebt)).BeginInit();
            this.SuspendLayout();

            this.homebt.Image = global::WinFrormsApp1.Properties.Resources.arrow3; // Set your image resource
            this.homebt.Location = new System.Drawing.Point(723, 12);
            this.homebt.Name = "homebt";
            this.homebt.Size = new System.Drawing.Size(48, 32);
            this.homebt.SizeMode = PictureBoxSizeMode.Zoom;
            this.homebt.TabIndex = 13;
            this.homebt.TabStop = false;
            this.homebt.Click += new EventHandler(this.homebt_Click);
            this.Controls.Add(this.homebt);

            ((System.ComponentModel.ISupportInitialize)(this.homebt)).EndInit();
            this.ResumeLayout(false);
        }

        // Event handler for homebt click event
        private void homebt_Click(object sender, EventArgs e)
        {
            // Navigate to the home screen or other logic
            MessageBox.Show("Returning to Home");
            this.Close(); // Or navigate to the home page
        }
    


        private void AnswerButton_Click(object sender, EventArgs e)
        {
            if (!isGameActive) return;

            Button btn = sender as Button;
            if (btn.Text == correctAnswer.ToString())
            {
                score += 10;
                lblScore.Text = "Score: " + score;
                questionCount++;

                if (questionCount >= totalQuestions)
                {
                    timer.Stop();
                    isGameActive = false; // Set the game as inactive
                    moveTimer.Stop();
                    jumpTimer.Stop();
                    MessageBox.Show("Game over! Your score is: " + score);
                    this.Close();
                }
                else
                {
                    GenerateQuestion();
                }
            }
            else
            {
                // Trigger the fox to jump
                if (!isJumping)
                {
                    isJumping = true;
                    foxOriginalY = spritePictureBox.Top;
                    jumpTimer.Start();
                }

                // Show the message after starting the jump
                MessageBox.Show("Wrong answer! Try again.");
            }
        }



        
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            using (Brush b = new SolidBrush(this.ForeColor))
            {
                e.Graphics.DrawString(this.Text, this.Font, b, -1, -1);
            }
        }

        private void lblEquals_Click(object sender, EventArgs e)
        {

        }
    }
}
