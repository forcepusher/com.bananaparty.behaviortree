using System;

namespace BananaParty.BehaviorTree
{
    /// <remarks>
    /// Code reusal for composites.
    /// </remarks>
    public abstract class SequentialComposite : Node
    {
        private readonly INode[] _childNodes;

        private readonly string _descriptionPrefix;

        public SequentialComposite(INode[] childNodes, string descriptionPrefix)
        {
            _childNodes = childNodes;
            _descriptionPrefix = descriptionPrefix;
        }

        protected abstract NodeStatus ContinueStatus { get; }

        protected abstract bool IsReactive { get; }

        protected int RunningChildIndex => Array.FindIndex(_childNodes,
            (childNode) => childNode.Status == NodeStatus.Running);

        public override NodeStatus OnExecute(float deltaTime)
        {
            int previousRunningChildIndex = RunningChildIndex;

            for (int childIterator = IsReactive || previousRunningChildIndex == -1 ? 0 : previousRunningChildIndex;
                childIterator < _childNodes.Length; childIterator += 1)
            {
                NodeStatus childNodeStatus = _childNodes[childIterator].Execute(deltaTime);

                if (childNodeStatus != ContinueStatus)
                {
                    for (int childToResetIterator = childIterator + 1;
                        childToResetIterator < _childNodes.Length; childToResetIterator += 1)
                    {
                        if (_childNodes[childToResetIterator].Status != NodeStatus.Idle)
                            _childNodes[childToResetIterator].Reset();
                        else
                            break;
                    }

                    return childNodeStatus;
                }
            }

            return ContinueStatus;
        }

        public override void OnReset()
        {
            foreach (INode child in _childNodes)
            {
                if (child.Status != NodeStatus.Idle)
                    child.Reset();
                else
                    break;
            }
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
