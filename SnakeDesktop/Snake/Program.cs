using System;
using System.Windows.Forms;

namespace Snake
{
    static class Program
    {
        /// <summary>
        /// Mechanika i interface aplikacji s¹ w pozosta³ych klasach
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmSnake());
        }


    }
}
