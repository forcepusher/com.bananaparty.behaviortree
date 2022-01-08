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
            if (Status != BehaviorNodeStatus.Running)
                _startTime = time;

            if (time < _startTime + _timeThreshold)
            {
                return ChildNode.Execute(time);
            }
            else
            {
                ChildNode.Reset();
                return BehaviorNodeStatus.Failure;
            }
        }

        public override void Reset()
        {
            base.Reset();

            _startTime = -1;
        }
    }
}
