namespace BananaParty.BehaviorTree.Tests
{
    public class MutableConstant : Node
    {
        public MutableConstant(NodeStatus startExecutionStatus)
        {
            NextExecutionStatus = startExecutionStatus;
        }

        public NodeStatus NextExecutionStatus { get; set; }

        public override NodeStatus OnExecute(float deltaTime)
        {
            return NextExecutionStatus;
        }
    }
}
