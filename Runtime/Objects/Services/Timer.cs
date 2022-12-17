using System;

namespace BananaParty.BehaviorTree
{
    public class Timer : ITimer
    {
        private readonly int _seconds;
        private DateTime _startTime;
        private bool _isStarted = false;

        public Timer(int seconds)
        {
            _seconds = seconds;
        }

        public void StartIfNot()
        {
            if (_isStarted) return;
            _startTime = DateTime.Now;
            _isStarted = true;
        }

        public bool IsEnded()
        {
            TimeSpan elapsed = DateTime.Now - _startTime;
            return elapsed.TotalSeconds >= _seconds;
        }

        public void Reset()
        {
            _isStarted = false;
        }

    }
}
