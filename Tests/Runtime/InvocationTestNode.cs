namespace BehaviorTree.Tests
{
    public class InvocationTestNode : IBehaviorNode
    {
        private readonly NodeExecutionStatus _statusToReturn;

        public int ExecutionCount { get; private set; } = 0;

        public InvocationTestNode(NodeExecutionStatus statusToReturn)
        {
            _statusToReturn = statusToReturn;
        }

        public NodeExecutionStatus Execute(long time)
        {
            ExecutionCount += 1;
            return _statusToReturn;
        }

        public NodeExecutionStatus Interrupt(long time) => _statusToReturn;

        public void WriteToGraph(INodeGraph nodeGraph)
        {
            nodeGraph.Write(nameof(SequenceNode));
        }
    }
}
