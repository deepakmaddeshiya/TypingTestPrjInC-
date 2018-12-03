using System;
using System.Windows.Forms;

namespace TypingTest
{
    static class MainPrj
    {
        
        [STAThread]
        static void Main()
        {
            //Enables visual styles for the application.
            Application.EnableVisualStyles();
            //call this method before the first window is created by your Windows Forms application.
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new FrmTypingTest());
        }
    }
}
