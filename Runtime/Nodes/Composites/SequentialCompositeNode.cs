using System;

namespace BananaParty.BehaviorTree
{
    /// <remarks>
    /// Code reusal for non-parallel composites.
    /// </remarks>
    public abstract class SequentialCompositeNode : BehaviorNode
    {
        private readonly IBehaviorNode[] _childNodes;
        private readonly bool _alwaysReevaluate;

        private readonly string _descriptionPrefix;

        public SequentialCompositeNode(IBehaviorNode[] childNodes, bool alwaysReevaluate, string descriptionPrefix)
        {
            _childNodes = childNodes;
            _alwaysReevaluate = alwaysReevaluate;

            _descriptionPrefix = descriptionPrefix;
        }

        protected abstract BehaviorNodeStatus ContinueStatus { get; }

        protected int RunningChildIndex => Array.FindIndex(_childNodes,
            (childNode) => childNode.Status == BehaviorNodeStatus.Running);

        public override BehaviorNodeStatus OnExecute(long time)
        {
            int runningChildIndex = RunningChildIndex;

            for (int childIterator = _alwaysReevaluate || runningChildIndex == -1 ? 0 : runningChildIndex;
                childIterator < _childNodes.Length; childIterator += 1)
            {
                BehaviorNodeStatus childNodeStatus = _childNodes[childIterator].Execute(time);

                if (childNodeStatus != ContinueStatus)
                {
                    // Interrupt nodes in front on failed reevaluation.
                    for (int childToResetIterator = childIterator + 1;
                        childToResetIterator <= runningChildIndex; childToResetIterator += 1)
                        _childNodes[childToResetIterator].Reset();

                    return childNodeStatus;
                }
            }

            return ContinueStatus;
        }

        public override void Reset()
        {
            base.Reset();

            foreach (IBehaviorNode child in _childNodes)
                child.Reset();
        }

        public override string Name => $"{_descriptionPrefix}{base.Name}{(_alwaysReevaluate ? '!' : string.Empty)}";

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
