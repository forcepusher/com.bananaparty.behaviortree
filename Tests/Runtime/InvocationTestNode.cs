namespace BananaParty.BehaviorTree.Tests
{
    public class InvocationTestNode : BehaviorNode
    {
        public int ExecutionCount { get; private set; } = 0;

        public InvocationTestNode(BehaviorNodeStatus statusToReturn)
        {
            Status = statusToReturn;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            ExecutionCount += 1;
            return Status;
        }
    }
}
