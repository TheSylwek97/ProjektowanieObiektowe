using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace Snake
{
    public partial class frmSnake : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();

        public frmSnake()
        {
            InitializeComponent();

            // Ustaw ustawinia na domyœlne
            new Settings();

            //Usaw szybkoœæ gry i uruchom licznik
            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            //Rozpocznij now¹ grê
            StartGame();
        }

        private void StartGame()
        {
            lblGameOver.Visible = false;

            // Ustaw ustawinia na domyœlne
            new Settings();

            //Stwórz nowy obiekt gracza
            Snake.Clear();
            Circle head = new Circle();
            head.X = 10;
            head.Y = 5;
            Snake.Add(head);

            lblSocre.Text = Settings.Score.ToString();
            GenerateFood();
        }

        //U³ó¿ losowo przedmioty 'pokarmu'
        private void GenerateFood()
        {
            int maxXPos = pbCanvas.Size.Width / Settings.Width;
            int maxYPos = pbCanvas.Size.Height / Settings.Height;

            Random random = new Random();
            food = new Circle();
            food.X = random.Next(0, maxXPos);
            food.Y = random.Next(0, maxYPos);

        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            //SprawdŸ zakoñczenie gry - GameOver
            if (Settings.GameOver == true)
            {
                //SprwdŸ czy Event jest aktywny
                if (Input.KeyPressed(Keys.Enter))
                {
                    StartGame();
                }
            }

            else
            {
                if (Input.KeyPressed(Keys.Right) && Settings.direction != Direction.Left)
                    Settings.direction = Direction.Right;

                else if (Input.KeyPressed(Keys.Left) && Settings.direction != Direction.Right)
                    Settings.direction = Direction.Left;

                else if (Input.KeyPressed(Keys.Up) && Settings.direction != Direction.Down)
                    Settings.direction = Direction.Up;

                else if (Input.KeyPressed(Keys.Down) && Settings.direction != Direction.Up)
                    Settings.direction = Direction.Down;

                MovePlayer();
            }

            //Odœwie¿ canvas
            pbCanvas.Invalidate();
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (Settings.GameOver != false)
            {
                //Ustaw kolor Sanke'a
                Brush snakeColor;


                //Rysuj Snake'a
                for (int i = 0; i < Snake.Count; i++)
                {                    
                    if (i == 0)
                        snakeColor = Brushes.Black; //malowanie g³owy Snake'a
                    else
                        snakeColor = Brushes.Green; // malowanie cia³a Snake'a

                    //Rysuj Snake'a
                    canvas.FillEllipse(snakeColor,
                                        new Rectangle(Snake[i].X * Settings.Width,
                                                      Snake[i].Y * Settings.Height,
                                                      Settings.Width, Settings.Height));
                    //Rysuj 'pokarm'
                    canvas.FillEllipse(Brushes.Red,
                                        new Rectangle(food.X * Settings.Width,
                                                      food.Y * Settings.Height,
                                                      Settings.Width, Settings.Height));
                }
            }
            else
            {
                string gameOver = "Koniec gry \nTwój wynik to: "
                                   + Settings.Score
                                   + "\nWciœnij Enter aby zagraæ ponownie";
                lblGameOver.Text = gameOver;
                lblGameOver.Visible = true;
            }
        }

        private void MovePlayer()
        {
            for (int i = Snake.Count - 1; i > 0; i--)
            {
                //Poruszaj g³ow¹
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Direction.Right:
                            Snake[i].X++;
                            break;

                        case Direction.Left:
                            Snake[i].X--;
                            break;

                        case Direction.Down:
                            Snake[i].Y++;
                            break;

                        case Direction.Up:
                            Snake[i].Y--;
                            break;
                    }
                }
                //Poruszaj reszt¹ cia³a
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
        }

        private void lblGameOver_Click(object sender, EventArgs e)
        {
            lblGameOver.Visible = false;
        }

    }
}
