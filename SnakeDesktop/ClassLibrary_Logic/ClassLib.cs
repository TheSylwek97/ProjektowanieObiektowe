using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibrary_Logic
{
    /// <summary>
    /// Możesz użyć enuma aby stworzyć nowe typy
    /// </summary>
    public enum Direction { Up, Down, Left, Right };

    /// <summary>
    /// Utwórz potrzebne do gry typy nadając im domyślne wartości w konstruktorze 
    /// </summary>

    public class Settings
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static int Speed { get; set; }
        public static int Score { get; set; }
        public static int Points { get; set; }
        public static bool GameOver { get; set; }
        public static Direction direction { get; set; }

        public Settings()
        {
            Width = 15;
            Height = 15;
            Speed = 14;
            Score = 0;
            Points = 10;
            GameOver = false;
            direction = Direction.Right;
        }
    }

    /// <summary>
    /// Stwórz położenie segmentu węża i jego pokarmu używając konstruktora
    /// </summary>
    public class Circle
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Circle()
        {
            X = 0;
            Y = 0;
        }
    }
    public class ClassLib 
    {
        /// <summary>
        /// Uruchom okno dialogowe zakończenia gry w przypadku skucia węża
        /// </summary>
        public static void Die()
        {
           Settings.GameOver = true;
        }


        /// <summary>
        /// Ułóż losowo przedmioty 'pokarmu', używając metodę random.Next
        /// Ustal granice obszaru pola dla wygenerowanego 'pokarmu'
        /// <remarks>
        /// Jako że elementy pokarmu mają być losowe ustal mi maksymalny zakres osi X i Y 
        /// z wyliczonych wcześniej ograniczeń
        /// </remarks>
        /// </summary>

        //Ułóż losowo przedmioty 'pokarmu'
        public static Circle GenerateFood(int width, int height) 
        {
            //Ustalenie granic obszaru pola do wygenerowania  'pokarmu'
            int maxXPos = width / Settings.Width;
            int maxYPos = height / Settings.Height;


            Random random = new Random();
            Circle food = new Circle();
            food.X = random.Next(0, maxXPos);
            food.Y = random.Next(0, maxYPos);

            return food;
        }



    }
}