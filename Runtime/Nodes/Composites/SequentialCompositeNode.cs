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

        private readonly string _descriptionPrefix;

        public SequentialCompositeNode(IBehaviorNode[] childNodes, bool alwaysReevaluate, string descriptionPrefix)
        {
            ChildNodes = childNodes;
            AlwaysReevaluate = alwaysReevaluate;

            _descriptionPrefix = descriptionPrefix;
        }

        protected abstract BehaviorNodeStatus ContinueStatus { get; }

        protected int RunningChildIndex => Array.FindIndex(ChildNodes,
            (childNode) => childNode.Status == BehaviorNodeStatus.Running);

        public override BehaviorNodeStatus OnExecute(long time)
        {
            int runningChildIndex = RunningChildIndex;

            for (int childIterator = AlwaysReevaluate || runningChildIndex == -1 ? 0 : runningChildIndex;
                childIterator < ChildNodes.Length; childIterator += 1)
            {
                BehaviorNodeStatus childNodeStatus = ChildNodes[childIterator].Execute(time);

                if (childNodeStatus != ContinueStatus)
                {
                    // Interrupt nodes in front on failed reevaluation.
                    for (int childToResetIterator = childIterator + 1;
                        childToResetIterator <= runningChildIndex; childToResetIterator += 1)
                        ChildNodes[childToResetIterator].Reset();

                    return childNodeStatus;
                }
            }

            return ContinueStatus;
        }

        public override void Reset()
        {
            base.Reset();

            foreach (IBehaviorNode child in ChildNodes)
                child.Reset();
        }

        public override string Name => $"{_descriptionPrefix}{base.Name}{(AlwaysReevaluate ? '!' : string.Empty)}";

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
