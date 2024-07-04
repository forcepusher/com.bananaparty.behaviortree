namespace BananaParty.BehaviorTree
{
    public class Timeout : Decorator
    {
        private readonly float _timeThreshold;

        private float _accumulatedTime = 0f;

        public Timeout(INode childNode, float timeLimit) : base(childNode)
        {
            _timeThreshold = timeLimit;
        }

        public override string Name => $"{base.Name} {_timeThreshold}";

        public override NodeStatus OnExecute(float deltaTime)
        {
            _accumulatedTime += deltaTime;

            if (_accumulatedTime < _timeThreshold)
            {
                NodeStatus childResult = ChildNode.Execute(deltaTime);
                if (childResult > NodeStatus.Running)
                    return childResult;
                else
                    return NodeStatus.Running;
            }
            else
            {
                ChildNode.Reset();
                return NodeStatus.Failure;
            }
        }

        public override void OnReset()
        {
            ChildNode.Reset();
            _accumulatedTime = 0f;
        }
    }
}
