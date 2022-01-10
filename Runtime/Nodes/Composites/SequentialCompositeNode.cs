using System;

namespace BananaParty.BehaviorTree
{
    /// <remarks>
    /// Code reusal for non-parallel composites.
    /// </remarks>
    public abstract class SequentialCompositeNode : BehaviorNode
    {
        protected readonly IBehaviorNode[] ChildNodes;
        protected readonly bool AlwaysReevaluate;

        public SequentialCompositeNode(IBehaviorNode[] childNodes, bool alwaysReevaluate = false)
        {
            ChildNodes = childNodes;
            AlwaysReevaluate = alwaysReevaluate;
        }

        protected int RunningChildIndex => Array.FindIndex(ChildNodes,
            (childNode) => childNode.Status == BehaviorNodeStatus.Running);

        public abstract override BehaviorNodeStatus OnExecute(long time);

        public override void Reset()
        {
            base.Reset();

            foreach (IBehaviorNode child in ChildNodes)
                child.Reset();
        }

        public override string Name => base.Name + (AlwaysReevaluate ? '!' : string.Empty);

        public override void WriteToGraph(ITreeGraph<IReadOnlyBehaviorNode> nodeGraph)
        {
            base.WriteToGraph(nodeGraph);

            nodeGraph.StartChildGroup(ChildNodes.Length);
            foreach (IBehaviorNode childNode in ChildNodes)
                childNode.WriteToGraph(nodeGraph);
            nodeGraph.EndChildGroup();
        }
    }
}
