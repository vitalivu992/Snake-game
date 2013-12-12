using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace snake_game
{
    public class Program
    {
        static MainForm app = new MainForm();
        //MyPipeline pp = app.pp1;
        static MyPipeline pp = new MyPipeline(app);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// [STAThread]

        public static void Thread1()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());
            
            //MainForm app = new MainForm();
            
            Application.Run(app);


        }

        public static void Thread2()
        {
            //MyPipeline pp = app.pp;
            //MyPipeline pp = new MyPipeline();
            pp.LoopFrames();

            Console.WriteLine("Test...");
            pp.Dispose();
        }
        
        static void Main()
        {
           
            
            Thread tid1 = new Thread(new ThreadStart(Thread1));
            Thread tid2 = new Thread(new ThreadStart(Thread2));

            
            tid2.Start();
            tid1.Start();

            //MyPipeline pp = new MyPipeline();
            //pp.LoopFrames();

            //Console.WriteLine("Exit");
            //pp.Dispose();
            
        }
    }
}
