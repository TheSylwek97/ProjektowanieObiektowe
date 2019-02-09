using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary_Logic;

namespace UnitTestLib
{
    [TestClass]
    public class UnitTestForLib
    {
        [DataTestMethod]
        [DataRow(15, 15, 14, 0, 10, false)]
        public void TestMethodForSettings(int w, int h, int s, int sc, int p, bool g)
        {
            new Settings();
            Assert.AreEqual(Settings.Width, w);
            Assert.AreEqual(Settings.Height, h);
            Assert.AreEqual(Settings.Speed, s);
            Assert.AreEqual(Settings.Score, sc);
            Assert.AreEqual(Settings.Points, p);
            Assert.AreEqual(Settings.GameOver, g);
        }

        [DataTestMethod]
        [DataRow(false)]
        public void TestMethodForNegationDie(bool a)
        {

            if (Settings.GameOver == true)
                Assert.AreEqual(Settings.GameOver, !a);
            else
                Assert.AreEqual(Settings.GameOver, a);

        }
    }
}
