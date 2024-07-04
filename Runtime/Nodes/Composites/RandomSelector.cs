using System;

namespace BananaParty.BehaviorTree
{
    public class RandomSelector : Node
    {
        private readonly INode[] _childNodes;

        private readonly string _descriptionPrefix;

        public RandomSelector(INode[] childNodes, string descriptionPrefix = "")
        {
            _childNodes = childNodes;
            _descriptionPrefix = descriptionPrefix;
        }

        protected int RunningChildIndex => Array.FindIndex(_childNodes,
            (childNode) => childNode.Status == NodeStatus.Running);

        public override NodeStatus OnExecute(float deltaTime)
        {
            int previousRunningChildIndex = RunningChildIndex;

            NodeStatus childNodeStatus;
            if (previousRunningChildIndex == -1)
            {
                int randomIndex = new Random().Next(_childNodes.Length);
                childNodeStatus = _childNodes[randomIndex].Execute(deltaTime);
            }
            else
            {
                childNodeStatus = _childNodes[previousRunningChildIndex].Execute(deltaTime);
            }

            return childNodeStatus;
        }

        public override void OnReset()
        {
            foreach (INode child in _childNodes)
            {
                if (child.Status != NodeStatus.Idle)
                {
                    child.Reset();
                }
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
