using System;

namespace BananaParty.BehaviorTree
{
    public class RandomWait : Node
    {
        private readonly float _minDuration;
        private readonly float _maxDuration;
        private readonly Random _random = new();

        private float _duration = 0f;
        private float _accumulatedTime = 0f;

        public RandomWait(float minDuration, float maxDuration)
        {
            _minDuration = minDuration;
            _maxDuration = maxDuration;
        }

        public override string Name => $"{base.Name} {_minDuration}-{_maxDuration}";

        public override NodeStatus OnExecute(float deltaTime)
        {
            if (Status == NodeStatus.Idle)
                _duration = (float)_random.NextDouble() * (_maxDuration - _minDuration) + _minDuration;

            _accumulatedTime += deltaTime;

            if (_accumulatedTime < _duration)
                return NodeStatus.Running;
            else
                return NodeStatus.Success;
        }

        public override void OnReset()
        {
            _duration = 0f;
            _accumulatedTime = 0f;
        }
    }
}
