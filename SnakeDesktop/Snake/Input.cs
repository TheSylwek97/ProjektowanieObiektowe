using System.Collections;
using System.Windows.Forms;

namespace Snake
{
    internal class Input
    {
        //Lista dostępnych klawiszy z klawiatury
        private static Hashtable keyTable = new Hashtable();

        //Wykonaj sprawdzenie by zobaczyć czy szczególny klawisz jest wciśnięty
        public static bool KeyPressed(Keys key)
        {
            if(keyTable[key] == null)
            {
                return false;
            }

            return (bool)keyTable[key];
        }

        //Wykryj czy klawisz klawiatury jest wciśnięty
        public static void ChangeState(Keys key, bool state)
        {
            keyTable[key] = state;
        }
    }
}
