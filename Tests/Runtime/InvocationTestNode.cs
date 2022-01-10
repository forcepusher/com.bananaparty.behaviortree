namespace BananaParty.BehaviorTree.Tests
{
    public class InvocationTestNode : BehaviorNode
    {
        private readonly BehaviorNodeStatus _statusToReturn;

        public int ExecutionCount { get; private set; } = 0;

        public InvocationTestNode(BehaviorNodeStatus statusToReturn)
        {
            _statusToReturn = statusToReturn;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            ExecutionCount += 1;
            return _statusToReturn;
        }
    }
}
