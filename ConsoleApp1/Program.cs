using System;
using System.Linq;
using System.Threading;
using ProgresBar;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var progressBar = new ProgressBar(20, "スタート", "エンド");
            progressBar.Start();
            foreach (var i in Enumerable.Range(0, 20))
            {
                progressBar.ShowMessage(i.ToString());
                progressBar.Step();
                Thread.Sleep(500);
            }
            progressBar.Finish();
        }
    }
}