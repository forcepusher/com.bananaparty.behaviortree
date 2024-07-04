namespace BananaParty.BehaviorTree
{
    /// <remarks>
    /// Code reusal for decorators.
    /// </remarks>
    public abstract class Decorator : Node
    {
        protected readonly INode ChildNode;

        public Decorator(INode childNode)
        {
            ChildNode = childNode;
        }

        public override void OnReset()
        {
            if (ChildNode.Status != NodeStatus.Idle)
                ChildNode.Reset();
        }

        public override void WriteToGraph(ITreeGraph<IReadOnlyNode> nodeGraph)
        {
            base.WriteToGraph(nodeGraph);

            nodeGraph.StartChildGroup(1);
            ChildNode.WriteToGraph(nodeGraph);
            nodeGraph.EndChildGroup();
        }
    }
}
