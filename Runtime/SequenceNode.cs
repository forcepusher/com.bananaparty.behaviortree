namespace BehaviorTree
{
    public class SequenceNode : IBehaviorNode
    {
        private readonly IBehaviorNode[] _childNodes;
        private readonly bool _alwaysReset;

        protected int RunningChildNodeIndex = -1;

        public SequenceNode(IBehaviorNode[] childNodes, bool alwaysReset = false)
        {
            _childNodes = childNodes;
            _alwaysReset = alwaysReset;
        }

        public NodeExecutionStatus Execute(long tickNumber)
        {
            // TODO: Wrong. Implement interruption here.
            if (_alwaysReset)
                RunningChildNodeIndex = -1;

            while (++RunningChildNodeIndex < _childNodes.Length)
            {
                NodeExecutionStatus childNodeStatus = _childNodes[RunningChildNodeIndex].Execute(tickNumber);
                if (childNodeStatus != NodeExecutionStatus.Success)
                    return childNodeStatus;
            }

            RunningChildNodeIndex = -1;

            return NodeExecutionStatus.Success;
        }

        // TODO: Implement it ofc.
        public NodeExecutionStatus Interrupt(long time) => throw new System.NotImplementedException();

        public void WriteToGraph(INodeGraph nodeGraph)
        {
            nodeGraph.Write(nameof(SequenceNode), RunningChildNodeIndex);
            nodeGraph.StartChildGroup(_childNodes.Length);

            foreach (IBehaviorNode childNode in _childNodes)
                childNode.WriteToGraph(nodeGraph);

            nodeGraph.EndChildGroup(_childNodes.Length);
        }
    }
}
