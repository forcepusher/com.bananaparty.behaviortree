using System;

namespace BananaParty.BehaviorTree
{
    public class Timer : ITimer
    {
        private readonly int _seconds;
        private DateTime _endTime;
        private bool _isStarted = false;

        public Timer(int seconds)
        {
            _seconds = seconds;
        }

        public void StartIfNot()
        {
            if (_isStarted) return;
            _endTime = DateTime.Now.AddSeconds(_seconds);
            _isStarted = true;
        }

        public bool IsEnded()
        {
            return DateTime.Now > _endTime;
        }

        public void Reset()
        {
            _isStarted = false;
        }
    }
}
