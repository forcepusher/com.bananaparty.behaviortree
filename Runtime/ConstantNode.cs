namespace BehaviorTree
{
    public class ConstantNode : IBehaviorNode
    {
        private readonly NodeExecutionStatus _statusToReturn;

        public ConstantNode(NodeExecutionStatus statusToReturn)
        {
            _statusToReturn = statusToReturn;
        }

        public NodeExecutionStatus Execute(long tickNumber)
        {
            return _statusToReturn;
        }

        public NodeExecutionStatus Interrupt(long time) => _statusToReturn;

        public void WriteToGraph(INodeGraph nodeGraph)
        {
            nodeGraph.Write(nameof(SequenceNode));
        }
    }
}
