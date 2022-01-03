namespace BehaviorTree
{
    public class SelectorNode : IBehaviorNode
    {
        private readonly IBehaviorNode[] _childNodes;
        private readonly bool _alwaysReset;

        protected int RunningChildIndex = -1;

        public SelectorNode(IBehaviorNode[] childNodes, bool alwaysReset = false)
        {
            _childNodes = childNodes;
            _alwaysReset = alwaysReset;
        }

        public NodeExecutionStatus Execute(long time)
        {
            if (_alwaysReset)
                RunningChildIndex = -1;

            while (++RunningChildIndex < _childNodes.Length)
            {
                NodeExecutionStatus childNodeStatus = _childNodes[RunningChildIndex].Execute(time);
                if (childNodeStatus != NodeExecutionStatus.Failure)
                {
                    if (childNodeStatus != NodeExecutionStatus.Running)
                        RunningChildIndex = -1;

                    return childNodeStatus;
                }
            }

            RunningChildIndex = -1;

            return NodeExecutionStatus.Success;
        }

        public void WriteToGraph(INodeGraph nodeGraph)
        {
            nodeGraph.Write(nameof(SelectorNode), RunningChildIndex);
            nodeGraph.StartChildGroup(_childNodes.Length);

            foreach (IBehaviorNode childNode in _childNodes)
                childNode.WriteToGraph(nodeGraph);

            nodeGraph.EndChildGroup();
        }
    }
}
