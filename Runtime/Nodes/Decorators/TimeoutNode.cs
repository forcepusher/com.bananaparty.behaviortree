namespace BehaviorTree
{
    public class TimeoutNode : DecoratorNode
    {
        private readonly long _duration;

        private long _startTime = -1;

        public TimeoutNode(IBehaviorNode childNode, long duration) : base(childNode)
        {
            _duration = duration;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (Status != BehaviorNodeStatus.Running)
                _startTime = time;

            if (time >= _startTime + _duration)
            {
                ChildNode.Reset();
                return BehaviorNodeStatus.Failure;
            }
            else
            {
                return ChildNode.Execute(time);
            }
        }

        public override void Reset()
        {
            base.Reset();

            _startTime = -1;
        }
    }
}
