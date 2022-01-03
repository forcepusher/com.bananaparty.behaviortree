namespace BehaviorTree
{
    public class ConstantNode : IBehaviorNode
    {
        private readonly NodeExecutionStatus _statusToReturn;

        public ConstantNode(NodeExecutionStatus statusToReturn)
        {
            _statusToReturn = statusToReturn;
        }

        public NodeExecutionStatus Execute(long time)
        {
            return _statusToReturn;
        }
    }
}
