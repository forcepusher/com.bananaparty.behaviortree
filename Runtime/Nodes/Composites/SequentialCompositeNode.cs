using System;

namespace BananaParty.BehaviorTree
{
    /// <remarks>
    /// Code reusal for composites.
    /// </remarks>
    public abstract class SequentialCompositeNode : BehaviorNode
    {
        private readonly IBehaviorNode[] _childNodes;

        private readonly string _descriptionPrefix;

        public SequentialCompositeNode(IBehaviorNode[] childNodes, string descriptionPrefix)
        {
            _childNodes = childNodes;
            _descriptionPrefix = descriptionPrefix;
        }

        protected abstract BehaviorNodeStatus ContinueStatus { get; }

        protected abstract bool IsReactive { get; }

        protected int RunningChildIndex => Array.FindIndex(_childNodes,
            (childNode) => childNode.Status == BehaviorNodeStatus.Running);

        public override BehaviorNodeStatus OnExecute(long time)
        {
            int previousRunningChildIndex = RunningChildIndex;

            for (int childIterator = IsReactive || previousRunningChildIndex == -1 ? 0 : previousRunningChildIndex;
                childIterator < _childNodes.Length; childIterator += 1)
            {
                BehaviorNodeStatus childNodeStatus = _childNodes[childIterator].Execute(time);

                if (childNodeStatus != ContinueStatus)
                {
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
