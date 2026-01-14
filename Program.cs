using CalculatorWinForms;
using System;
using System.Windows.Forms;

namespace CalculatorWinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Launch your calculator form
            Application.Run(new Calculator());
        }
    }
}
