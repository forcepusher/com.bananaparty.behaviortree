namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// Still a selector that executes sequentially, but multiple nodes can enter running state.
    /// </summary>
    public class ParallelSelectorNode : ParallelCompositeNode
    {
        public ParallelSelectorNode(IBehaviorNode[] childNodes, string descriptionPrefix = "") : base(childNodes, descriptionPrefix) { }

        protected override BehaviorNodeStatus CompletionStatus => BehaviorNodeStatus.Failure;

        protected override bool ShouldContinueOnStatus(BehaviorNodeStatus status) => status == BehaviorNodeStatus.Failure;
    }
}
