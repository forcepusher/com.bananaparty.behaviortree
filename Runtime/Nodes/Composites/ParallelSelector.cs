namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// Still a selector that executes sequentially, but multiple nodes can enter running state.
    /// </summary>
    public class ParallelSelector : ParallelComposite
    {
        public ParallelSelector(INode[] childNodes, string descriptionPrefix = "") : base(childNodes, descriptionPrefix) { }

        protected override NodeStatus CompletionStatus => NodeStatus.Failure;

        protected override bool ShouldContinueOnStatus(NodeStatus status) => status == NodeStatus.Failure;
    }
}
