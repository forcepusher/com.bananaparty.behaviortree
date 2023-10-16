namespace BananaParty.BehaviorTree
{
    /// <remarks>
    /// Code reusal for parallel composites.
    /// </remarks>
    public abstract class ParallelCompositeNode : BehaviorNode
    {
        private readonly IBehaviorNode[] _childNodes;

        private readonly string _descriptionPrefix;

        public ParallelCompositeNode(IBehaviorNode[] childNodes, string descriptionPrefix)
        {
            _childNodes = childNodes;

            _descriptionPrefix = descriptionPrefix;
        }

        protected abstract BehaviorNodeStatus CompletionStatus { get; }

        protected abstract bool ShouldContinueOnStatus(BehaviorNodeStatus status);

        public override BehaviorNodeStatus OnExecute(long time)
        {
            bool allNodesCompleted = true;
            foreach (IBehaviorNode childNode in _childNodes)
            {
                BehaviorNodeStatus childNodeStatus = childNode.Execute(time);
                if (childNodeStatus != BehaviorNodeStatus.Running)
                {
                    if (!ShouldContinueOnStatus(childNodeStatus))
                    {
                        foreach (IBehaviorNode childNodeToReset in _childNodes)
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

            return BehaviorNodeStatus.Running;
        }

        public override void OnReset()
        {
            foreach (IBehaviorNode child in _childNodes)
            {
                if (child.Status != BehaviorNodeStatus.Idle)
                {
                    child.Reset();
                }
                else
                {
                    break;
                }
            }
        }

        public override string Name => $"{_descriptionPrefix}{base.Name}";

        public override void WriteToGraph(ITreeGraph<IReadOnlyBehaviorNode> nodeGraph)
        {
            base.WriteToGraph(nodeGraph);

            nodeGraph.StartChildGroup(_childNodes.Length);
            foreach (IBehaviorNode childNode in _childNodes)
                childNode.WriteToGraph(nodeGraph);
            nodeGraph.EndChildGroup();
        }
    }
}
