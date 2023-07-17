namespace BananaParty.BehaviorTree.Tests
{
    public class InvocationTestNode : BehaviorNode
    {
        public int ExecutionCount { get; private set; } = 0;

        public InvocationTestNode(BehaviorNodeStatus initialStatus)
        {
            Status = initialStatus;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            ExecutionCount += 1;
            return Status;
        }
    }
}
