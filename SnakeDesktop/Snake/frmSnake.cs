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

            // Ustaw ustawinia na domy�lne
            new Settings();

            //Ustaw szybko�� gry i uruchom licznik, aby Snake m�g� si� p�niej porusza�
            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            //Rozpocznij now� gr�
            StartGame();
        }

        private void StartGame()
        {
            //Okno zako�czenia gry ukryte
            lblGameOver.Visible = false;

            //Ustaw ustawiania na domy�lne
            new Settings();

            //Stw�rz nowy obiekt gracza
            Snake.Clear();
            Circle head = new Circle();
            head.X = 0;
            head.Y = 0;
            Snake.Add(head);

            //Zapisz wynik do wy�wietlania
            lblSocre.Text = Settings.Score.ToString();

            food = ClassLib.GenerateFood(pbCanvas.Size.Width, pbCanvas.Size.Height);
        }

        /*
        //U�� losowo przedmioty 'pokarmu'
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
        /// Sprawd� czy gra jest zako�czona, je�li tak daj mo�liwo�� ponownego jest w��czenia.
        /// Gdy gra jest uruchomiona ustal kierunek w�a i dodaj metod� umo�liwiaj�c�  jego poruszanie.
        /// <remarks>
        /// Dodaj metod� od�wie�ania pictureBoxa do aktualizowania grafik
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateScreen(object sender, EventArgs e)
        {

            //Sprawd� zako�czenie gry - GameOver
            if (Settings.GameOver == true)
            {
                //Sprwd� czy Enter zosta� aktywowany uruchamiaj�cy gr� od nowa
                if (Input.KeyPressed(Keys.Enter))
                {
                    StartGame();
                }
            }

            //Ustaw kierunek do poruszania si� w�a
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

            //Od�wie� canvas(pictureBox) i aktualizauj grafiki
            pbCanvas.Invalidate();
        }

        /// <summary>
        /// Rysuj�c w�a ustal r�ne kolory dla w�a i pokarmu - opcjonalnie inne kolory dla g�owy w�a i jego cia�a
        /// U�yj p�tli, aby ka�dy segment w�a by� wy�wietlany.
        /// Utal co ma si� wy�witla� po przegraniu 
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


                //Rysowanie element�w
                for (int i = 0; i < Snake.Count; i++)
                {                    
                    if (i == 0)
                        snakeColor = Brushes.Black; //malowanie g�owy Snake'a
                    else
                        snakeColor = Brushes.DimGray; // malowanie cia�a Snake'a

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
                string gameOver = "Koniec gry! \nTw�j wynik to: "
                                   + Settings.Score
                                   + "\nWci�nij Enter aby zagra� ponownie";
                lblGameOver.Text = gameOver;
                lblGameOver.Visible = true;
            }
        }

        private void MovePlayer()
        {
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                //Poruszaj g�ow�
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

                    //Pobierz maxymaln� pozycje X i Y
                    int maxXPos = pbCanvas.Width / Settings.Width;
                    int maxYPos = pbCanvas.Height / Settings.Height;

                    //Wykryj kolizje z ramk� gry
                    if(Snake[i].X < 0 || Snake[i].Y < 0
                        || Snake[i].X >= maxXPos || Snake[i].Y >= maxYPos)
                    {
                        ClassLib.Die();
                    }

                    //Wykryj kolizje z reszt� cia�a
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
                //Poruszaj reszt� cia�a
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
        }

        //Naliczanie punkt�w
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
            //Powi�kszanie d�ugo�ci w�a
            
            food.X = Snake[Snake.Count - 1].X;
            food.Y = Snake[Snake.Count - 1].Y;
            Snake.Add(food);

            //Naliczanie punkt�w
            Settings.Score += Settings.Points;
            lblSocre.Text = Settings.Score.ToString();

            food = ClassLib.GenerateFood(pbCanvas.Size.Width, pbCanvas.Size.Height);
        }*/

        //Uruchomienie event�w aby reagowa�y na klawisze klawiatury
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