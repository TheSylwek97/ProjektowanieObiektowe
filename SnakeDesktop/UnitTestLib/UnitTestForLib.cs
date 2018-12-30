using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary_Logic;
using System.Collections.Generic;
using System.Drawing;
using Snake;

namespace UnitTestLib
{
    [TestClass]
    public class UnitTestForLib 
    {
        [TestMethod]
        public void TestMethodForSettings()
        {
            Console.WriteLine("Pokaż usawtenia domyślne:");
            Console.WriteLine("Width " + Settings.Width);
            Console.WriteLine("Height " + Settings.Height);
            Console.WriteLine("Speed " + Settings.Speed);
            Console.WriteLine("Score " + Settings.Score);
            Console.WriteLine("Points " + Settings.Points);
            Console.WriteLine("GameOver " + Settings.GameOver);
            Console.WriteLine("direction " + Settings.direction);
        }

        [TestMethod]
        public void TestMethodForDie()
        {
           // Console.WriteLine(ClassLib.Die());
        }
        
        [TestMethod]
        public void TestMethodForGenerateFood() 
        {

        }

        [TestMethod]
        public void TestMethodForEat()
        {

        }
    }
}

