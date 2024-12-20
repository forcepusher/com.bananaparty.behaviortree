namespace BananaParty.BehaviorTree
{
    /// <remarks>
    /// Code reusal for parallel composites.
    /// </remarks>
    public abstract class ParallelComposite : Node
    {
        private readonly INode[] _childNodes;

        private readonly string _descriptionPrefix;

        public ParallelComposite(INode[] childNodes, string descriptionPrefix)
        {
            _childNodes = childNodes;

            _descriptionPrefix = descriptionPrefix;
        }

        protected abstract NodeStatus CompletionStatus { get; }

        protected abstract bool ShouldContinueOnStatus(NodeStatus status);

        public override NodeStatus OnExecute(float deltaTime)
        {
            bool allNodesCompleted = true;
            foreach (INode childNode in _childNodes)
            {
                NodeStatus childNodeStatus = childNode.Execute(deltaTime);
                if (childNodeStatus != NodeStatus.Running)
                {
                    if (!ShouldContinueOnStatus(childNodeStatus))
                    {
                        foreach (INode childNodeToReset in _childNodes)
                            if (childNodeToReset != childNode)
                                childNodeToReset.Reset();

                        return childNodeStatus;
                    }
                }
                else
                {
                    allNodesCompleted = false;
                }
            }

            if (allNodesCompleted)
                return CompletionStatus;

            return NodeStatus.Running;
        }

        public override void OnReset()
        {
            foreach (INode child in _childNodes)
                if (child.Status != NodeStatus.Idle)
                    child.Reset();
        }

        public override string Name => $"{_descriptionPrefix}{base.Name}";

        public override void WriteToGraph(ITreeGraph<IReadOnlyNode> nodeGraph)
        {
            base.WriteToGraph(nodeGraph);

            nodeGraph.StartChildGroup(_childNodes.Length);
            foreach (INode childNode in _childNodes)
                childNode.WriteToGraph(nodeGraph);
            nodeGraph.EndChildGroup();
        }
    }
}
