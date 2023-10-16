namespace BananaParty.BehaviorTree
{
    /// <remarks>
    /// Code reusal for decorators.
    /// </remarks>
    public abstract class DecoratorNode : BehaviorNode
    {
        protected readonly IBehaviorNode ChildNode;

        public DecoratorNode(IBehaviorNode childNode)
        {
            ChildNode = childNode;
        }

        public override void OnReset()
        {
            if (ChildNode.Status != BehaviorNodeStatus.Idle)
                ChildNode.Reset();
        }

        public override void WriteToGraph(ITreeGraph<IReadOnlyBehaviorNode> nodeGraph)
        {
            base.WriteToGraph(nodeGraph);

            nodeGraph.StartChildGroup(1);
            ChildNode.WriteToGraph(nodeGraph);
            nodeGraph.EndChildGroup();
        }
    }
}
