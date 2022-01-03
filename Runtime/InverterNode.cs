namespace BehaviorTree
{
    public class InverterNode : IBehaviorNode
    {
        private readonly IBehaviorNode _childNode;

        public InverterNode(IBehaviorNode childNode)
        {
            _childNode = childNode;
        }

        public NodeExecutionStatus Execute(long time)
        {
            NodeExecutionStatus childResult = _childNode.Execute(time);
            return childResult switch
            {
                NodeExecutionStatus.Success => NodeExecutionStatus.Failure,
                NodeExecutionStatus.Failure => NodeExecutionStatus.Success,
                _ => childResult,
            };
        }
    }
}
