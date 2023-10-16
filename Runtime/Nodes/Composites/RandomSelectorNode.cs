using System;

namespace BananaParty.BehaviorTree
{
    public class RandomSelectorNode : BehaviorNode
    {
        private readonly IBehaviorNode[] _childNodes;

        private readonly string _descriptionPrefix;

        public RandomSelectorNode(IBehaviorNode[] childNodes, string descriptionPrefix = "")
        {
            _childNodes = childNodes;
            _descriptionPrefix = descriptionPrefix;
        }

        protected int RunningChildIndex => Array.FindIndex(_childNodes,
            (childNode) => childNode.Status == BehaviorNodeStatus.Running);

        public override BehaviorNodeStatus OnExecute(long time)
        {
            int previousRunningChildIndex = RunningChildIndex;

            BehaviorNodeStatus childNodeStatus;
            if (previousRunningChildIndex == -1)
            {
                int randomIndex = new Random().Next(_childNodes.Length);
                childNodeStatus = _childNodes[randomIndex].Execute(time);
            }
            else
            {
                childNodeStatus = _childNodes[previousRunningChildIndex].Execute(time);
            }

            return childNodeStatus;
        }

        public override void OnReset()
        {
            foreach (IBehaviorNode child in _childNodes)
            {
                if (child.Status != BehaviorNodeStatus.Idle)
                {
                    child.Reset();
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
