﻿namespace BananaParty.BehaviorTree
{
    /// <remarks>
    /// Code reusal for parallel composites.
    /// </remarks>
    public abstract class ParallelCompositeNode : BehaviorNode
    {
        protected readonly IBehaviorNode[] ChildNodes;

        private readonly string _descriptionPrefix;

        public ParallelCompositeNode(IBehaviorNode[] childNodes, string descriptionPrefix)
        {
            ChildNodes = childNodes;

            _descriptionPrefix = descriptionPrefix;
        }

        protected abstract BehaviorNodeStatus ContinueStatus { get; }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            bool allNodesCompleted = true;
            foreach (IBehaviorNode childNode in ChildNodes)
            {
                BehaviorNodeStatus childNodeStatus = childNode.Execute(time);
                if (childNodeStatus != BehaviorNodeStatus.Running)
                {
                    if (childNodeStatus != ContinueStatus)
                    {
                        foreach (IBehaviorNode childNodeToReset in ChildNodes)
                            if (childNodeToReset != childNode)
                                childNodeToReset.Reset();

                        return childNodeStatus;
                    }
                }
                else
                {
                    allNodesCompleted = false;
                }
            }

            if (allNodesCompleted)
                return ContinueStatus;

            return BehaviorNodeStatus.Running;
        }

        public override void Reset()
        {
            base.Reset();

            foreach (IBehaviorNode child in ChildNodes)
                child.Reset();
        }

        public override string Name => $"{_descriptionPrefix}{base.Name}";

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
