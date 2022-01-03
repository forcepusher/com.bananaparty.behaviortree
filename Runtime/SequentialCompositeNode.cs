using System;

namespace BehaviorTree
{
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
            (childNode) => childNode.Status == NodeExecutionStatus.Running);

        public abstract override NodeExecutionStatus OnExecute(long time);

        public override void OnReset()
        {
            foreach (IBehaviorNode child in ChildNodes)
                child.Reset();
        }

        public override void WriteToGraph(INodeGraph nodeGraph)
        {
            nodeGraph.Write($"{GetType().Name}{(AlwaysReevaluate ? '!' : string.Empty)}", Status);

            nodeGraph.StartChildGroup(ChildNodes.Length);
            foreach (IBehaviorNode childNode in ChildNodes)
                childNode.WriteToGraph(nodeGraph);
            nodeGraph.EndChildGroup();
        }
    }
}
