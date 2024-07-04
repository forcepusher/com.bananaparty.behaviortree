namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// Sequentially runs multiple nodes in parallel and returns as soon as first child completes.
    /// </summary>
    public class ParallelFirstComplete : ParallelComposite
    {
        public ParallelFirstComplete(INode[] childNodes, string descriptionPrefix = "") : base(childNodes, descriptionPrefix) { }

        protected override NodeStatus CompletionStatus => NodeStatus.Success;

        protected override bool ShouldContinueOnStatus(NodeStatus status) => false;
    }
}
