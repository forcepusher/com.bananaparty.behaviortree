namespace BananaParty.BehaviorTree
{
    public class TimeoutNode : DecoratorNode
    {
        private readonly long _timeThreshold;

        private long _startTime = -1;

        public TimeoutNode(IBehaviorNode childNode, long timeThreshold) : base(childNode)
        {
            _timeThreshold = timeThreshold;
        }

        public override string Name => $"{base.Name} {_timeThreshold}";

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (Status == BehaviorNodeStatus.Idle)
                _startTime = time;

            if (ChildNode.Status == BehaviorNodeStatus.Failure || ChildNode.Status == BehaviorNodeStatus.Success)
            {
                BehaviorNodeStatus childStatus = ChildNode.Execute(time);

                if (childStatus == BehaviorNodeStatus.Running)
                    _startTime = time;

                return childStatus;
            }

            if (time < _startTime + _timeThreshold)
                return ChildNode.Execute(time);

            ChildNode.Reset();
            return BehaviorNodeStatus.Failure;
        }

        public override void OnReset()
        {
            _startTime = -1;
        }
    }
}
