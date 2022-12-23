namespace BananaParty.BehaviorTree.Tests
{
    public class MutableConstantNode : BehaviorNode
    {
        public MutableConstantNode(BehaviorNodeStatus startExecutionStatus)
        {
            NextExecutionStatus = startExecutionStatus;
        }

        public BehaviorNodeStatus NextExecutionStatus { get; set; }

        protected override BehaviorNodeStatus OnExecute()
        {
            return NextExecutionStatus;
        }
    }
}
