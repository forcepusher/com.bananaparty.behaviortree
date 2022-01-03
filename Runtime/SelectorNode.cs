namespace BehaviorTree
{
    public class SelectorNode : SequentialCompositeNode
    {
        public SelectorNode(IBehaviorNode[] childNodes, bool alwaysReevaluate = false) : base(childNodes, alwaysReevaluate) { }

        public override NodeExecutionStatus OnExecute(long time)
        {
            int runningChildIndex = RunningChildIndex;

            for (int childIterator = (AlwaysReevaluate || runningChildIndex == -1) ? 0 : runningChildIndex;
                childIterator < ChildNodes.Length; childIterator += 1)
            {
                NodeExecutionStatus childNodeStatus = ChildNodes[childIterator].Execute(time);

                if (childNodeStatus != NodeExecutionStatus.Failure)
                {
                    // Interrupt nodes in front on failed reevaluation.
                    for (int childToResetIterator = childIterator + 1;
                        childToResetIterator <= runningChildIndex; childToResetIterator += 1)
                        ChildNodes[childToResetIterator].Reset();

                    return childNodeStatus;
                }
            }

            return NodeExecutionStatus.Failure;
        }
    }
}
