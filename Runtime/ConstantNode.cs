namespace BehaviorTree
{
    public class ConstantNode : BehaviorNode
    {
        private readonly NodeExecutionStatus _statusToReturn;

        public ConstantNode(NodeExecutionStatus statusToReturn)
        {
            _statusToReturn = statusToReturn;
        }

        public override NodeExecutionStatus OnExecute(long time)
        {
            return _statusToReturn;
        }
    }
}
