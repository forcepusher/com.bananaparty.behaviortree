using System;

namespace BananaParty.BehaviorTree
{
    public class Timer : ITimer
    {
        private readonly double _seconds;
        private DateTime _endTime;
        private bool _isStarted = false;

        /// <summary>
        /// A timer that will count down the specified number of <paramref name="seconds"/>.
        /// </summary>
        public Timer(double seconds)
        {
            _seconds = seconds;
        }

        /// <summary>
        /// Starts the timer if it hasn't already started.
        /// </summary>
        public void StartIfNot()
        {
            if (_isStarted) return;
            _endTime = DateTime.Now.AddSeconds(_seconds);
            _isStarted = true;
        }

        /// <summary>
        /// Checks if the timer has expired.
        /// </summary>
        /// <returns>True if the timer has been completed.</returns>
        public bool IsEnded()
        {
            if (!_isStarted) return false;
            return DateTime.Now > _endTime;
        }

        /// <summary>
        /// Resets the timer and allows it to be restarted.
        /// </summary>
        public void Reset()
        {
            _isStarted = false;
        }
    }
}
