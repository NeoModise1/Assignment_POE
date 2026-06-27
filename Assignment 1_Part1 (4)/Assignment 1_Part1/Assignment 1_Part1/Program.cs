using System;
using System.Windows;

namespace Assignment_1_Part1
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // GUI only — final deliverable
            var app = new Application();
            app.Run(new Part2_POE.MainWindow());
        }
    }
}
