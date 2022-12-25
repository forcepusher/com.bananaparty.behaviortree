namespace BananaParty.BehaviorTree.Tests
{
    public class InvocationTestNode : BehaviorNode
    {
        public int ExecutionCount { get; private set; } = 0;
        public BehaviorNodeStatus ResultStatus { get; set; } = BehaviorNodeStatus.Idle;

        public InvocationTestNode(BehaviorNodeStatus statusToReturn)
        {
            ResultStatus = statusToReturn;
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            ExecutionCount += 1;
            return ResultStatus;
        }
    }
}
