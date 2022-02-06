namespace BananaParty.BehaviorTree.Tests
{
    public class MutableConstantNode : BehaviorNode
    {
        public MutableConstantNode(BehaviorNodeStatus startExecutionStatus)
        {
            NextExecutionStatus = startExecutionStatus;
        }

        public BehaviorNodeStatus NextExecutionStatus { get; set; }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            return NextExecutionStatus;
        }
    }
}
