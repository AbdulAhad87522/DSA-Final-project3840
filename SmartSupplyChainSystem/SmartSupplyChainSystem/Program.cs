using System;
using System.Windows.Forms;
using SmartSupplyChainSystem.Forms;

namespace SmartSupplyChainSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}