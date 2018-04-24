using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;

namespace ProgresBar
{
    public class ProgressBar
    {
        private static readonly string ClearLine = "\r" + (char) 0x1B + "[2K";
        private int _max;
        private readonly string _startMessage;
        private readonly string _finishMessage;
        private string _prefix;
        private char _fillChar;
        private char _progressChar;

        private int _current;
        private bool _hasFinished;

        public ProgressBar(int max, string startMessage, string finishMessage, string prefix = "-----> ",
            char progressChar = '░', char fillChar = '█')
        {
            _max = max;
            _startMessage = startMessage;
            _finishMessage = finishMessage;
            _prefix = prefix;
            _fillChar = fillChar;
            _progressChar = progressChar;
            _current = 0;
            _hasFinished = false;
        }

        public int ProgressMax
        {
            get => _max;
            set => _max = value;
        }

        public string Prefix
        {
            get => _prefix;
            set => _prefix = value;
        }

        public char FillChar
        {
            get => _fillChar;
            set => _fillChar = value;
        }

        public char ProgressChar
        {
            get => _progressChar;
            set => _progressChar = value;
        }

        public bool HasFinished => _hasFinished;

        public void Start()
        {
            var start = string.Format("{0}{1}", _prefix, _startMessage);
            WriteLine(start);
            ShowProgressBar();
        }

        public void Finish()
        {
            var finish = string.Format("\n{0}{1}", _prefix, _finishMessage);
            WriteLine(finish);
            _hasFinished = true;
        }

        public void Step()
        {
            if (_hasFinished)
            {
                return;
            }

            _current++;
            ShowProgressBar();

            if (_current >= _max)
            {
                _hasFinished = true;
            }
            
        }

        public void StepTo(int n)
        {
            if (n > _max || n <= _current)
            {
                return;
            }

            _current = n;
            ShowProgressBar();
            if (_current >= _max)
            {
                _hasFinished = true;
            }
        }

        public void ShowMessage(string msg)
        {
            if (_hasFinished)
            {
                return;
            }
            
            Write(ClearLine);
            WriteLine(_prefix + msg);
            ShowProgressBar();
        }

        private void ShowProgressBar()
        {
            string remainingStep;
            if (_max > 999)
            {
                remainingStep = _current > 999 ? "999+/999+ " : string.Format("{0,4} {1}", _current, "999+");
            }
            else
            {
                remainingStep = string.Format("{0,3}/{1}", _current, _max);
            }

            var progRate = (double)_current / _max;
            var progRateStr = string.Format("{0, 6:#0.0%}", progRate);
            var remainingStepAndProgRate = string.Format(" {0} {1}", remainingStep, progRateStr);

            var progBarWidth = WindowWidth - _prefix.Length - remainingStepAndProgRate.Length;
            //var progBarWidth = width - prefixLength - remainingStepAndProgRate.Length;
            var fillStrLength = (int)(progBarWidth * progRate);
            var progStrLength = progBarWidth - fillStrLength;

            var sb = new StringBuilder();
            Enumerable
                .Range(0, fillStrLength)
                .Aggregate(sb, (builder, i) => builder.Append(_fillChar));
            Enumerable
                .Range(0, progStrLength)
                .Aggregate(sb, (builder, i) => builder.Append(_progressChar));
            
            var output = string.Format("{0}{1}{2}", _prefix, sb.ToString(), remainingStepAndProgRate);
            Write(ClearLine);
            Write(output);
        }
        
    }
}