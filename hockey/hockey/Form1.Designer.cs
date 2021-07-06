
namespace hockey
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.playground = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.enemy_score = new System.Windows.Forms.Label();
            this.my_score = new System.Windows.Forms.Label();
            this.enemy_goal = new System.Windows.Forms.PictureBox();
            this.my_goal = new System.Windows.Forms.PictureBox();
            this.enemy_racket = new System.Windows.Forms.PictureBox();
            this.ball = new System.Windows.Forms.PictureBox();
            this.my_racket = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.playground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enemy_goal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.my_goal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy_racket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.my_racket)).BeginInit();
            this.SuspendLayout();
            // 
            // playground
            // 
            this.playground.Controls.Add(this.label1);
            this.playground.Controls.Add(this.enemy_score);
            this.playground.Controls.Add(this.my_score);
            this.playground.Controls.Add(this.enemy_goal);
            this.playground.Controls.Add(this.my_goal);
            this.playground.Controls.Add(this.enemy_racket);
            this.playground.Controls.Add(this.ball);
            this.playground.Controls.Add(this.my_racket);
            this.playground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playground.Location = new System.Drawing.Point(0, 0);
            this.playground.Name = "playground";
            this.playground.Size = new System.Drawing.Size(800, 450);
            this.playground.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(4, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(528, 55);
            this.label1.TabIndex = 7;
            this.label1.Text = "Press M to open menu";
            // 
            // enemy_score
            // 
            this.enemy_score.AutoSize = true;
            this.enemy_score.BackColor = System.Drawing.Color.Transparent;
            this.enemy_score.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enemy_score.Location = new System.Drawing.Point(3, 85);
            this.enemy_score.Name = "enemy_score";
            this.enemy_score.Size = new System.Drawing.Size(264, 64);
            this.enemy_score.TabIndex = 6;
            this.enemy_score.Text = "Enemy: 0";
            // 
            // my_score
            // 
            this.my_score.AutoSize = true;
            this.my_score.BackColor = System.Drawing.Color.Transparent;
            this.my_score.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.my_score.Location = new System.Drawing.Point(3, 0);
            this.my_score.Name = "my_score";
            this.my_score.Size = new System.Drawing.Size(189, 64);
            this.my_score.TabIndex = 5;
            this.my_score.Text = "You: 0";
            // 
            // enemy_goal
            // 
            this.enemy_goal.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.enemy_goal.Location = new System.Drawing.Point(43, 388);
            this.enemy_goal.Name = "enemy_goal";
            this.enemy_goal.Size = new System.Drawing.Size(316, 50);
            this.enemy_goal.TabIndex = 4;
            this.enemy_goal.TabStop = false;
            this.enemy_goal.Click += new System.EventHandler(this.enemy_goal_Click);
            // 
            // my_goal
            // 
            this.my_goal.BackColor = System.Drawing.SystemColors.Highlight;
            this.my_goal.Location = new System.Drawing.Point(427, 344);
            this.my_goal.Name = "my_goal";
            this.my_goal.Size = new System.Drawing.Size(316, 50);
            this.my_goal.TabIndex = 3;
            this.my_goal.TabStop = false;
            // 
            // enemy_racket
            // 
            this.enemy_racket.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.enemy_racket.Location = new System.Drawing.Point(366, 200);
            this.enemy_racket.Name = "enemy_racket";
            this.enemy_racket.Size = new System.Drawing.Size(68, 50);
            this.enemy_racket.TabIndex = 2;
            this.enemy_racket.TabStop = false;
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.Maroon;
            this.ball.Location = new System.Drawing.Point(309, 146);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(50, 50);
            this.ball.TabIndex = 1;
            this.ball.TabStop = false;
            // 
            // my_racket
            // 
            this.my_racket.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.my_racket.Location = new System.Drawing.Point(279, 279);
            this.my_racket.Name = "my_racket";
            this.my_racket.Size = new System.Drawing.Size(68, 50);
            this.my_racket.TabIndex = 0;
            this.my_racket.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.playground);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.playground.ResumeLayout(false);
            this.playground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enemy_goal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.my_goal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy_racket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.my_racket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel playground;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.PictureBox my_racket;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox enemy_racket;
        private System.Windows.Forms.PictureBox enemy_goal;
        private System.Windows.Forms.PictureBox my_goal;
        private System.Windows.Forms.Label my_score;
        private System.Windows.Forms.Label enemy_score;
        private System.Windows.Forms.Label label1;
    }
}

