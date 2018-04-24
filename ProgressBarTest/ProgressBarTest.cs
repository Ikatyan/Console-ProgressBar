using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Threading;
using ProgresBar;
using Xunit;

namespace ProgressBarTest
{
    public class ProgressBarTest
    {
        [Fact]
        public void Test1()
        {
            const string start = "さあ、始まりました！";
            const string end = "あーっと、ここで終了です！";
            var progressBar = new ProgressBar(20, start, end);
            progressBar.Start();
            Thread.Sleep(1000);
            progressBar.Step();
            Thread.Sleep(1000);
            progressBar.Step();
            Thread.Sleep(1000);
            progressBar.ShowMessage("ワッショイワッショイ");
            progressBar.Step();
            progressBar.Finish();
            Assert.Equal(1, 1);
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(1, 1);
        }

        [Fact]
        public void Test3()
        {

            var i = Enumerable.Range(0, 0).Aggregate(0, (i1, i2) => i1 + i2);
            var list = new List<int>{0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
        }
    }
}