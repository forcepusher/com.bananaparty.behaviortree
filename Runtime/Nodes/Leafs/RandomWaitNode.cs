using System;

namespace BananaParty.BehaviorTree
{
    public class RandomWaitNode : BehaviorNode
    {
        private long _duration;
        private readonly int _minDuration;
        private readonly int _maxDuration;

        private long _startTime = -1;

        public RandomWaitNode(int minDuration, int maxDuration)
        {
            _minDuration = minDuration;
            _maxDuration = maxDuration;
        }

        public override string Name => $"{base.Name} {_minDuration}-{_maxDuration}";

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (Status == BehaviorNodeStatus.Idle)
            {
                _startTime = time;
                _duration = new Random().Next(_minDuration, _maxDuration);
            }

            if (time < _startTime + _duration)
                return BehaviorNodeStatus.Running;
            else
                return BehaviorNodeStatus.Success;
        }

        public override void OnReset()
        {
            _startTime = -1;
            _duration = -1;
        }
    }
}
