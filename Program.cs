using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace snake_game
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MyPipeline pp = new MyPipeline();
            pp.LoopFrames();
            pp.Dispose();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
