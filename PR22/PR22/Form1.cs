using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR22
{
    public partial class Form1 : Form
    {
        Rectangle Rectangle = new Rectangle(10, 10, 200, 100);
        Rectangle Circle = new Rectangle(220, 10, 150, 150);
        Rectangle Square = new Rectangle(380, 10, 150, 150);

        bool RectangleClicked=false;
        bool CircleClicked=false;
        bool SquareClicked=false;
        int LastClicked = 0;

        int Rectangle_1=0;
        int Rectangle_2=0;
        int Circle_1=0;
        int Circle_2=0;
        int Square_1=0;
        int Square_2=0;

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Purple, Circle);
            e.Graphics.FillRectangle(Brushes.DarkBlue, Square);
            e.Graphics.FillRectangle(Brushes.LightGreen, Rectangle);

            if (RectangleClicked == true)
            {
                e.Graphics.FillEllipse(Brushes.Purple, Circle);
                e.Graphics.FillRectangle(Brushes.DarkBlue, Square);
                e.Graphics.FillRectangle(Brushes.LightGreen, Rectangle);
            }
            if (CircleClicked == true)
            {
                e.Graphics.FillRectangle(Brushes.DarkBlue, Square);
                e.Graphics.FillRectangle(Brushes.LightGreen, Rectangle);
                e.Graphics.FillEllipse(Brushes.Purple, Circle);
            }
            if (SquareClicked == true)
            {
                e.Graphics.FillEllipse(Brushes.Purple, Circle);
                e.Graphics.FillRectangle(Brushes.LightGreen, Rectangle);
                e.Graphics.FillRectangle(Brushes.DarkBlue, Square);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.X < Rectangle.X + Rectangle.Width) && (e.X > Rectangle.X))
            {
                if ((e.Y < Rectangle.Y + Rectangle.Height) && (e.Y > Rectangle.Y))
                {
                    RectangleClicked = true;
                    Rectangle_1=e.X-Rectangle.X;
                    Rectangle_2=e.Y-Rectangle.Y;
                    LastClicked = 1;
                }
            }
            if ((e.X < Circle.X + Circle.Width) && (e.X > Circle.X))
            {
                if ((e.Y < Circle.Y + Circle.Height) && (e.Y > Circle.Y))
                {
                    CircleClicked = true;
                    Circle_1 = e.X - Circle.X;
                    Circle_2 = e.Y - Circle.Y;
                    LastClicked = 2;

                }
            }
            if ((e.X < Square.X + Square.Width) && (e.X > Square.X))
            {
                if ((e.Y < Square.Y + Square.Height) && (e.Y > Square.Y))
                {
                    SquareClicked = true;
                    Square_1 = e.X - Square.X;
                    Square_2 = e.Y - Square.Y;
                    LastClicked = 3;

                }
            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            RectangleClicked= false;
            SquareClicked = false;
            CircleClicked= false;
            if (label3.Text == "Синий квадрат!")
            {
                Square.X = 380;
                Square.Y = 10;
            }
            if (label3.Text == "Фиолетовый круг!")
            {
                Circle.X = 220;
                Circle.Y = 10;
            }
            if (label3.Text == "Салатовый Прямоугольник!")
            {
                Rectangle.X = 10;
                Rectangle.Y = 10;
            }

            if (LastClicked == 1)
            {
                if ((label2.Location.X < Rectangle.X + Rectangle.Width) && (label2.Location.X > Rectangle.X))
                {
                    if ((label2.Location.Y < Rectangle.Y + Rectangle.Height) && (label2.Location.Y > Rectangle.Y))
                    {
                        int X = Rectangle.X;
                        int Y = Rectangle.Y;
                        int dX = Rectangle_1;
                        int dY = Rectangle_2;

                        Rectangle.X = Circle.X;
                        Rectangle.Y = Circle.Y;
                        Rectangle_1 = Circle_1;
                        Rectangle_2= Circle_2;

                        Circle.X =X;
                        Circle.Y = Y;
                        Circle_1 = dX;
                        Circle_2 = dY;
                        label3.Text = "Поменялось!";
                    }
                }
            }
            if (LastClicked == 2)
            {
                if ((label2.Location.X < Circle.X + Circle.Width) && (label2.Location.X > Circle.X))
                {
                    if ((label2.Location.Y < Circle.Y + Circle.Height) && (label2.Location.Y > Circle.Y))
                    {
                        int X = Circle.X;
                        int Y = Circle.Y;
                        int dX = Circle_1;
                        int dY = Circle_2;

                        Circle.X = Square.X;
                        Circle.Y = Square.Y;
                        Circle_1 = Square_1;
                        Circle_2 = Square_2;

                        Square.X = X;
                        Square.Y = Y;
                        Square_1 = dX;
                        Square_2 = dY;
                        label3.Text = "Поменялось!";
                    }
                }
            }
            if (LastClicked == 3)
            {
                if ((label2.Location.X < Square.X + Square.Width) && (label2.Location.X > Square.X))
                {
                    if ((label2.Location.Y < Square.Y + Square.Height) && (label2.Location.Y > Square.Y))
                    {
                        int X = Square.X;
                        int Y = Square.Y;
                        int dX = Square_1;
                        int dY = Square_2;

                        Square.X = Rectangle.X;
                        Square.Y = Rectangle.Y;
                        Square_1 = Rectangle_1;
                        Square_2 = Rectangle_2;

                        Rectangle.X = X;
                        Rectangle.Y = Y;
                        Rectangle_1 = dX;
                        Rectangle_2 = dY;
                        label3.Text = "Поменялось!";
                    }
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (RectangleClicked==true)
            {
                Rectangle.X = e.X - Rectangle_1;
                Rectangle.Y = e.Y - Rectangle_2;
            }
            if (CircleClicked == true)
            {
                Circle.X = e.X - Circle_1;
                Circle.Y = e.Y - Circle_2;
            }
            if (SquareClicked == true)
            {
                Square.X = e.X - Square_1;
                Square.Y = e.Y - Square_2;
            }
            if ((label1.Location.X < Square.X + Square.Width) && (label1.Location.X>Square.X))
            {
                if ((label1.Location.Y < Square.Y + Square.Height) && (label1.Location.Y > Square.Y))
                {
                    label3.Text = "Синий квадрат!";
                }
            }
            if ((label1.Location.X < Circle.X + Circle.Width) && (label1.Location.X > Circle.X))
            {
                if ((label1.Location.Y < Circle.Y + Circle.Height) && (label1.Location.Y > Circle.Y))
                {
                    label3.Text = "Фиолетовый круг!";
                }
            }
            if ((label1.Location.X < Rectangle.X + Rectangle.Width) && (label1.Location.X > Rectangle.X))
            {
                if ((label1.Location.Y < Rectangle.Y + Rectangle.Height) && (label1.Location.Y > Rectangle.Y))
                {
                    label3.Text = "Салатовый Прямоугольник!";
                }
            }
            pictureBox1.Invalidate();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, PaintEventArgs e)
        {
            
        }


    }
}
