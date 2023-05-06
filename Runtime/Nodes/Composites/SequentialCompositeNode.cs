using System;

namespace BananaParty.BehaviorTree
{
    /// <remarks>
    /// Code reusal for non-parallel composites.
    /// </remarks>
    public abstract class SequentialCompositeNode : BehaviorNode
    {
        private readonly IBehaviorNode[] _childNodes;
        private readonly bool _isReactive;

        private readonly string _descriptionPrefix;

        public SequentialCompositeNode(IBehaviorNode[] childNodes, bool isReactive, string descriptionPrefix)
        {
            _childNodes = childNodes;
            _isReactive = isReactive;

            _descriptionPrefix = descriptionPrefix;
        }

        public override bool ReactiveEvaluation => true;

        protected abstract BehaviorNodeStatus ContinueStatus { get; }

        protected int RunningChildIndex => Array.FindIndex(_childNodes,
            (childNode) => childNode.Status == BehaviorNodeStatus.Running);

        public override BehaviorNodeStatus OnExecute(long time)
        {
            int previousRunningChildIndex = RunningChildIndex;

            for (int childIterator = _isReactive || previousRunningChildIndex == -1 ? 0 : previousRunningChildIndex;
                childIterator < _childNodes.Length; childIterator += 1)
            {
                bool isReevaluationIteration = childIterator < previousRunningChildIndex;
                if (isReevaluationIteration && !_childNodes[childIterator].ReactiveEvaluation)
                    continue;

                BehaviorNodeStatus childNodeStatus = _childNodes[childIterator].Execute(time);

                if (childNodeStatus != ContinueStatus)
                {
                    if (isReevaluationIteration)
                        for (int childToResetIterator = childIterator + 1;
                            childToResetIterator <= previousRunningChildIndex; childToResetIterator += 1)
                            _childNodes[childToResetIterator].Reset();

                    return childNodeStatus;
                }
            }

            return ContinueStatus;
        }

        public override void OnReset()
        {
            foreach (IBehaviorNode child in _childNodes)
                child.Reset();
        }

        public override string Name => $"{_descriptionPrefix}{base.Name}{(_isReactive ? '!' : string.Empty)}";

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
