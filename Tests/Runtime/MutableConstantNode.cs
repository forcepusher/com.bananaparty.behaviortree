namespace BananaParty.BehaviorTree.Tests
{
    public class MutableConstantNode : BehaviorNode
    {
        protected override string Name => "Mutable Constant Node";

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
