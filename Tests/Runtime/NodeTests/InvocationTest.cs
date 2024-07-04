namespace BananaParty.BehaviorTree.Tests
{
    public class InvocationTest : Node
    {
        public int ExecutionCount { get; private set; } = 0;

        public InvocationTest(NodeStatus initialStatus)
        {
            Status = initialStatus;
        }

        public override NodeStatus OnExecute(float deltaTime)
        {
            ExecutionCount += 1;
            return Status;
        }
    }
}
