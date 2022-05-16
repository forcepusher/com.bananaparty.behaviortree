namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// Sequentially runs multiple nodes in parallel and returns as soon as first child completes.
    /// </summary>
    public class ParallelFirstCompleteNode : ParallelCompositeNode
    {
        public ParallelFirstCompleteNode(IBehaviorNode[] childNodes, string descriptionPrefix = "") : base(childNodes, descriptionPrefix) { }

        protected override BehaviorNodeStatus CompletionStatus => BehaviorNodeStatus.Success;

        protected override bool ShouldContinueOnStatus(BehaviorNodeStatus status) => false;
    }
}
