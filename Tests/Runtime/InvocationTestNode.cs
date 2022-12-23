namespace BananaParty.BehaviorTree.Tests
{
    public class InvocationTestNode : BehaviorNode
    {
        public int ExecutionCount { get; private set; } = 0;
        public BehaviorNodeStatus Status { get => _state; set => _state = value; }

        public InvocationTestNode(BehaviorNodeStatus statusToReturn)
        {
            _state = statusToReturn;
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            ExecutionCount += 1;
            return _state;
        }
    }
}
