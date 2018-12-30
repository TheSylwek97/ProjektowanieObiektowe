using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ClassLibrary_Logic;

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

            //Ustaw szybkoœæ gry i uruchom licznik, aby Snake móg³ siê póŸniej poruszaæ
            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            //Rozpocznij now¹ grê
            StartGame();
        }

        private void StartGame()
        {
            //Okno zakoñczenia gry ukryte
            lblGameOver.Visible = false;

            //Ustaw ustawiania na domyœlne
            new Settings();

            //Stwórz nowy obiekt gracza
            Snake.Clear();
            Circle head = new Circle();
            head.X = 0;
            head.Y = 0;
            Snake.Add(head);

            //Zapisz wynik do wyœwietlania
            lblSocre.Text = Settings.Score.ToString();

            food = ClassLib.GenerateFood(pbCanvas.Size.Width, pbCanvas.Size.Height);
        }

        /*
        //U³ó¿ losowo przedmioty 'pokarmu'
        private void GenerateFood()
        {
            //Ustalenie granic obszaru pola do wygenerowania  'pokarmu'
            int maxXPos = pbCanvas.Size.Width / Settings.Width;
            int maxYPos = pbCanvas.Size.Height / Settings.Height;

            Random random = new Random();
            food = new Circle();
            food.X = random.Next(0, maxXPos);
            food.Y = random.Next(0, maxYPos);

        }*/

        /// <summary>
        /// Aktualizowanie okna
        /// SprawdŸ czy gra jest zakoñczona, jeœli tak daj mo¿liwoœæ ponownego jest w³¹czenia.
        /// Gdy gra jest uruchomiona ustal kierunek wê¿a i dodaj metodê umo¿liwiaj¹c¹  jego poruszanie.
        /// <remarks>
        /// Dodaj metodê odœwie¿ania pictureBoxa do aktualizowania grafik
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateScreen(object sender, EventArgs e)
        {

            //SprawdŸ zakoñczenie gry - GameOver
            if (Settings.GameOver == true)
            {
                //SprwdŸ czy Enter zosta³ aktywowany uruchamiaj¹cy grê od nowa
                if (Input.KeyPressed(Keys.Enter))
                {
                    StartGame();
                }
            }

            //Ustaw kierunek do poruszania siê wê¿a
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

            //Odœwie¿ canvas(pictureBox) i aktualizauj grafiki
            pbCanvas.Invalidate();
        }

        /// <summary>
        /// Rysuj¹c wê¿a ustal ró¿ne kolory dla wê¿a i pokarmu - opcjonalnie inne kolory dla g³owy wê¿a i jego cia³a
        /// U¿yj pêtli, aby ka¿dy segment wê¿a by³ wyœwietlany.
        /// Utal co ma siê wyœwitlaæ po przegraniu 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (!Settings.GameOver)
            {
                //Do ustawienia koloru Sanke'a
                Brush snakeColor;


                //Rysowanie elementów
                for (int i = 0; i < Snake.Count; i++)
                {                    
                    if (i == 0)
                        snakeColor = Brushes.Black; //malowanie g³owy Snake'a
                    else
                        snakeColor = Brushes.DimGray; // malowanie cia³a Snake'a

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
                string gameOver = "Koniec gry! \nTwój wynik to: "
                                   + Settings.Score
                                   + "\nWciœnij Enter aby zagraæ ponownie";
                lblGameOver.Text = gameOver;
                lblGameOver.Visible = true;
            }
        }

        private void MovePlayer()
        {
            for (int i = Snake.Count - 1; i >= 0; i--)
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

                    //Pobierz maxymaln¹ pozycje X i Y
                    int maxXPos = pbCanvas.Width / Settings.Width;
                    int maxYPos = pbCanvas.Height / Settings.Height;

                    //Wykryj kolizje z ramk¹ gry
                    if(Snake[i].X < 0 || Snake[i].Y < 0
                        || Snake[i].X >= maxXPos || Snake[i].Y >= maxYPos)
                    {
                        ClassLib.Die();
                    }

                    //Wykryj kolizje z reszt¹ cia³a
                    for (int j=1; j<Snake.Count; j++)
                    {
                        if(Snake[i].X == Snake[j].X &&
                            Snake[i].Y == Snake[j].Y)
                        {
                            ClassLib.Die();
                        }
                    }

                    //Wykryj kolizje z jedzeniem
                    if(Snake[0].X == food.X &&
                        Snake[0].Y == food.Y)
                    {
                        ClassLib.Eat(food, Snake);
                        food = ClassLib.GenerateFood(pbCanvas.Size.Width, pbCanvas.Size.Height);
                        UpdataSocre();

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

        //Naliczanie punktów
        private void UpdataSocre()
        {
            lblSocre.Text = Settings.Score.ToString();
        }

        /*
        private void Die()
        {
            Settings.GameOver = true;
        }*/

        /*
        private void Eat()
        {
            //Powiêkszanie d³ugoœci wê¿a
            
            food.X = Snake[Snake.Count - 1].X;
            food.Y = Snake[Snake.Count - 1].Y;
            Snake.Add(food);

            //Naliczanie punktów
            Settings.Score += Settings.Points;
            lblSocre.Text = Settings.Score.ToString();

            food = ClassLib.GenerateFood(pbCanvas.Size.Width, pbCanvas.Size.Height);
        }*/

        //Uruchomienie eventów aby reagowa³y na klawisze klawiatury
        private void frmSnake_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void frmSnake_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }
    }
}