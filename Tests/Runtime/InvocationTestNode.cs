namespace BehaviorTree.Tests
{
    public class InvocationTestNode : BehaviorNode
    {
        private readonly NodeExecutionStatus _statusToReturn;

        public int ExecutionCount { get; private set; } = 0;

        public InvocationTestNode(NodeExecutionStatus statusToReturn)
        {
            _statusToReturn = statusToReturn;
        }

        public override NodeExecutionStatus OnExecute(long time)
        {
            ExecutionCount += 1;
            return _statusToReturn;
        }
    }
}
