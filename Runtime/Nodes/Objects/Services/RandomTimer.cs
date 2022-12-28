using System;

namespace BananaParty.BehaviorTree
{
    public class RandomTimer : ITimer
    {
        private readonly double _fromSeconds;
        private readonly double _toSeconds;
        private DateTime _endTime;
        private bool _isStarted = false;

        /// <summary>
        /// A timer that will count down the specified number of <paramref name="seconds"/>.
        /// </summary>
        public RandomTimer(double fromSeconds, double toSeconds)
        {
            if (fromSeconds < 0 || toSeconds < 0)
                throw new ArgumentException("Time must be greater than zero.");
            if (fromSeconds < toSeconds)
                Swap(ref fromSeconds, ref toSeconds);
            _fromSeconds = fromSeconds;
            _toSeconds = toSeconds;
        }

        /// <summary>
        /// Starts the timer if it hasn't already started.
        /// </summary>
        public void StartIfNot()
        {
            if (_isStarted) return;
            _endTime = DateTime.Now.AddSeconds(GetRandomSeconds());
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

        private double GetRandomSeconds()
        {
            Random random = new Random();
            return random.NextDouble() * (_toSeconds - _fromSeconds) + _fromSeconds;
        }

        private void Swap(ref double x, ref double y)
        {
            double temp = x;
            x = y;
            y = temp;
        }
    }
}
