using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hockey
{    
    public partial class Form1 : Form
    {  
        public class goal_class
        {
            private int Top;
            private int Bottom;
            private int Left;
            private int Right;

            private int counter_enemy_goals = 0;
            private const int max_point = 10;
            public goal_class() { counter_enemy_goals = 0; }

            public goal_class(int T, int B, int L, int R)
            {
                counter_enemy_goals = 0;

                Top = T;
                Bottom = B;
                Left = L;
                Right = R;
            }

            public int start_Top(int new_location_top)
            {
                Top = new_location_top - (new_location_top / 20);// - (new_location_top / 10);
                return Top;
            }

            public int start_Left(int new_location_right)
            {
                Left = new_location_right - (new_location_right / 2) - 100;
                return Left;
            }

            public void start_Right(int new_Right) { Right = new_Right; }

            public void start_Bottom(int new_Bottom) { Bottom = new_Bottom; }

            public bool is_Goal(ref ball_class _ball)
            {
                int cross_Width = 0, cross_Height = 0;

                if (this.Left <= _ball.get_Left() && _ball.get_Left() <= this.Right) { cross_Width = this.Right - _ball.get_Left(); }
                if (this.Left <= _ball.get_Right() && _ball.get_Right() <= this.Right) { cross_Width = _ball.get_Right() - this.Left; }
                if (this.Top <= _ball.get_Top() && _ball.get_Top() <= this.Bottom) { cross_Height = this.Bottom - _ball.get_Top(); }
                if (this.Top <= _ball.get_Bottom() && _ball.get_Bottom() <= this.Bottom) { cross_Height = _ball.get_Bottom() - this.Top; }

                if (cross_Height * cross_Width > 0) 
                {
                    counter_enemy_goals++;
                    return true; 
                }
                return false;
            }

            public int get_counter_enemy_goals() { return counter_enemy_goals; }

        }

        public class racket_class
        {
            protected int Top;
            protected int Bottom;
            protected int Left;
            protected int Right;

            protected int Width;

            protected int speed_Left = 0;
            protected int speed_Top = 0;

            protected const int mass = 2;

            public racket_class() { }

            public racket_class(int T, int B, int L, int R) 
            {
                Top = T;
                Bottom = B;
                Right = R;
                Left = L;
                Width = Right - Left;
            }

            public int start_Top(int new_location) { return (Top = 0); }

            public int start_Left(int new_location) { return (Left = 0); }

            public int change_Top() { return 0; }

            public int change_Left() { return 0; }

            public void change_Right(int new_Right) { Right = new_Right; }

            public void change_Bottom(int new_Bottom) { Bottom = new_Bottom; }

            public void change_speed_Left(int new_Left) { speed_Left = new_Left - Left; }

            public void change_speed_Top(int new_Top) { speed_Top = new_Top - Top; }

            public bool is_touch_ball(ref ball_class _ball)
            {
                int cross_Width = 0, cross_Height = 0;

                if (this.Left <= _ball.get_Left() && _ball.get_Left() <= this.Right) { cross_Width = this.Right - _ball.get_Left(); }
                if (this.Left <= _ball.get_Right() && _ball.get_Right() <= this.Right) { cross_Width = _ball.get_Right() - this.Left; }
                if (this.Top <= _ball.get_Top() && _ball.get_Top() <= this.Bottom) { cross_Height = this.Bottom - _ball.get_Top(); }
                if (this.Top <= _ball.get_Bottom() && _ball.get_Bottom() <= this.Bottom) { cross_Height = _ball.get_Bottom() - this.Top; }

                if(cross_Height * cross_Width > 0) { return true; }
                return false;
            }

            public int get_mass() { return mass; }

            public int get_speed_Top() { return speed_Top; }

            public int get_speed_Left() { return speed_Left; }

            public int get_Bottom() { return Bottom; }

            public void reverse_speed_Top() { speed_Top *= (-1); }

            public void reverse_speed_Left() { speed_Left *= (-1); }
        }

        public class my_racket_class : racket_class
        {
            public my_racket_class() { }

            public my_racket_class(int T, int B, int L, int R)
            {
                Top = T;
                Bottom = B;
                Right = R;
                Left = L;
                Width = Right - Left;
            }

            public int start_Top(int new_location)
            {
                Top = new_location - (new_location / 10);
                return Top;
            }

            public int change_Left()
            {
                change_speed_Left(Cursor.Position.X - (Width / 2));
                Left = Cursor.Position.X - (Width / 2);
                return Left;
            }

            public int change_Top()
            {
                if (Cursor.Position.Y >= playground_middle_Height)
                {
                    change_speed_Top(Cursor.Position.Y);
                    Top = Cursor.Position.Y;
                }
                return Top;
            }
        }

        public class enemy_racket_class : racket_class
        {

            private const int enemy_start_speed_Left = 10;
            private const int enemy_start_speed_Top = 10;

            public enemy_racket_class() 
            {
                speed_Left = enemy_start_speed_Left;
                speed_Top = enemy_start_speed_Top;
            }

            public enemy_racket_class(int T, int B, int L, int R) 
            {
                speed_Left = enemy_start_speed_Left;
                speed_Top = enemy_start_speed_Top;

                Top = T;
                Bottom = B;
                Left = L;
                Right = R;
            }

            public int start_Top(int new_location)
            {
                Top = new_location + 10;
                return Top;
            }

            public int change_Top() { return (Top += speed_Top); }

            public int change_Left() { return (Left += speed_Left); }

            public void thinking(ref ball_class _ball)
            {
                if(Right <= _ball.get_Left() && speed_Left < 0 || _ball.get_Right() <= Left && speed_Left > 0)
                {
                    reverse_speed_Left();
                }
                if(Bottom <= _ball.get_Top() && speed_Top < 0 || _ball.get_Bottom() <= Top && speed_Top > 0)
                {
                    reverse_speed_Top();
                }
            }


        }

        public class ball_class
        {
            private int speed_Left = 10;
            private int speed_Top = 10;

            private int Top;
            private int Bottom;
            private int Left;
            private int Right;

            private double friction_Left = 0;
            private const double delta_friction_Left = 0.1;
            private double friction_Top = 0;
            private const double delta_friction_Top = 0.1;

            private const int mass = 1;

            public ball_class() { }

            public ball_class(int T, int B, int L, int R)
            {
                Top = T;
                Bottom = B;
                Left = L;
                Right = R;
            }

            public int change_Left() 
            {
                friction_Left += delta_friction_Left;
                if(friction_Left > 1 && speed_Left > 0)
                {
                    if (speed_Left > 0) { speed_Left -= 1; }
                    else { speed_Left += 1; }
                    friction_Left -= 1;
                }
                Left += speed_Left;
                return Left;
            }
            
            public int change_Top() 
            {
                friction_Top += delta_friction_Top;
                if (friction_Top > 1 && speed_Top > 0)
                {
                    if (speed_Top > 0) { speed_Top -= 1; }
                    else { speed_Top += 1; }
                    friction_Top -= 1;
                }
                Top += speed_Top;
                return Top;
            }

            public void change_Right(int new_Right) { Right = new_Right; }

            public void change_Bottom(int new_Bottom) { Bottom = new_Bottom; }

            public void reverse_speed_Top() { speed_Top *= (-1); }

            public void reverse_speed_Left() { speed_Left *= (-1); }

            public void change_speed_Top(int new_speed_Top) { speed_Top += new_speed_Top; }

            public void change_speed_Left(int new_speed_Left) { speed_Left += new_speed_Left; }

            public int get_Left() { return Left; }

            public int get_Right() { return Right; }

            public int get_Top() { return Top; }

            public int get_Bottom() { return Bottom; }

            public int get_area() { return (Right - Left) * (Bottom - Top); }

            public int get_mass() { return mass; }

            
        }

        public my_racket_class _my_racket;
        public ball_class _ball;
        public enemy_racket_class _enemy_racket;
        public goal_class _my_goal;
        public goal_class _enemy_goal;

        public const int playground_middle_Height = 320;
        public bool _FREEZE_GAME = false;
        public bool _START_NEW_GAME = false;
        public bool _CLOSE_GAME = false;
        public bool _FIRST_OPEN_MENU_FORM = false;

        public Form1()
        {
            InitializeComponent();

            timer1.Enabled = true;
            //Cursor.Hide();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            initialization_objects();

            my_racket_start_location();

            enemy_racket_start_location();

            my_goal_start_location();

            enemy_goal_start_location();

            show_goal();


        }

        public void initialization_objects()
        {
            _my_racket = new my_racket_class(my_racket.Top, my_racket.Bottom, my_racket.Left, my_racket.Right);
            _enemy_racket = new enemy_racket_class();
            _ball = new ball_class(ball.Top, ball.Bottom, ball.Left, ball.Right);
            _my_goal = new goal_class(my_goal.Top, my_goal.Bottom, my_goal.Left, my_goal.Right);
            _enemy_goal = new goal_class(enemy_goal.Top, enemy_goal.Bottom, enemy_goal.Left, enemy_goal.Right);
        }

        public void my_racket_start_location()
        {
            my_racket.Top = _my_racket.start_Top(playground.Bottom);
        }

        public void enemy_racket_start_location()
        {
            enemy_racket.Top = _enemy_racket.start_Top(playground.Top);
        }

        public void my_goal_start_location()
        {
            my_goal.Top = _my_goal.start_Top(playground.Bottom);
            my_goal.Left = _my_goal.start_Left(playground.Right);
            _my_goal.start_Right(my_goal.Right);
            _my_goal.start_Bottom(my_goal.Bottom);
            
        }

        public void enemy_goal_start_location()
        {
            enemy_goal.Top = _enemy_goal.start_Top(playground.Top);
            enemy_goal.Left = _enemy_goal.start_Left(playground.Right);
            _enemy_goal.start_Right(enemy_goal.Right);
            _enemy_goal.start_Bottom(enemy_goal.Bottom);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!_FIRST_OPEN_MENU_FORM)
            {
                _FIRST_OPEN_MENU_FORM = true;
                open_menu_form();
            }

            if(_CLOSE_GAME) { this.Close(); }

            if(_START_NEW_GAME)
            {
                initialization_objects();

                my_racket_start_location();

                enemy_racket_start_location();

                my_goal_start_location();

                enemy_racket_start_location();

                show_goal();

                _START_NEW_GAME = false;
            }

            if (!_FREEZE_GAME)
            {
                my_racket_action();

                enemy_racket_action();

                goals_action();

                ball_action();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape) { this.Close(); }
            
            if(e.KeyCode == Keys.M) { open_menu_form(); }
            
        }

        private void enemy_goal_Click(object sender, EventArgs e)
        {

        }

        public void my_racket_action()
        {
            my_racket.Left = _my_racket.change_Left();
            my_racket.Top = _my_racket.change_Top();
            _my_racket.change_Right(my_racket.Right);
            _my_racket.change_Bottom(my_racket.Bottom);

            if (_my_racket.is_touch_ball(ref _ball))
            {
                _ball.change_speed_Top(_my_racket.get_speed_Top());
                _ball.change_speed_Left(_my_racket.get_speed_Left());
            }
        }

        public void enemy_racket_action()
        { 

            if (_ball.get_Top() <= playground_middle_Height)
            {
                _enemy_racket.thinking(ref _ball);

                enemy_racket.Left = _enemy_racket.change_Left();
                enemy_racket.Top = _enemy_racket.change_Top();
                _enemy_racket.change_Right(enemy_racket.Right);
                _enemy_racket.change_Bottom(enemy_racket.Bottom);

                if (_enemy_racket.is_touch_ball(ref _ball))
                {
                    _ball.change_speed_Top(_enemy_racket.get_speed_Top());
                    _ball.change_speed_Left(_enemy_racket.get_speed_Left());
                }

                if (enemy_racket.Left <= playground.Left || enemy_racket.Right >= playground.Right) { _enemy_racket.reverse_speed_Left(); }

                if (enemy_racket.Top <= playground.Top || enemy_racket.Bottom >= playground.Bottom) { _enemy_racket.reverse_speed_Top(); }

            }
        }

        public void goals_action()
        {
            if (_my_goal.is_Goal(ref _ball)) { enemy_score.Text = "Enemy: " + _my_goal.get_counter_enemy_goals().ToString(); }
            if (_enemy_goal.is_Goal(ref _ball)) { my_score.Text = "You: " + _enemy_goal.get_counter_enemy_goals().ToString(); }

            //if(_my_goal.get_counter_enemy_goals() == 1 || _enemy_goal.get_counter_enemy_goals() == 1) { menu.Visible = true; }
        }

        public void ball_action()
        {
            ball.Left = _ball.change_Left();
            ball.Top = _ball.change_Top();
            _ball.change_Right(ball.Right);
            _ball.change_Bottom(ball.Bottom);

            if (ball.Left <= playground.Left || ball.Right >= playground.Right) { _ball.reverse_speed_Left(); }

            if (ball.Top <= playground.Top || ball.Bottom >= playground.Bottom) { _ball.reverse_speed_Top(); }
        }

        public void show_goal()
        {
            enemy_score.Text = "Enemy: " + _my_goal.get_counter_enemy_goals().ToString(); 
            my_score.Text = "You: " + _enemy_goal.get_counter_enemy_goals().ToString(); 
        }

        public void open_menu_form()
        {
            MenuForm menu_form = new MenuForm(this);
            menu_form.Show();
            _FREEZE_GAME = true;
        }

    }
}
