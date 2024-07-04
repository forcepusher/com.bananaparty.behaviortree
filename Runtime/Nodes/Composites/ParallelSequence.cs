namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// Still a sequence that executes sequentially, but multiple nodes can enter running state.
    /// </summary>
    public class ParallelSequence : ParallelComposite
    {
        public ParallelSequence(INode[] childNodes, string descriptionPrefix = "") : base(childNodes, descriptionPrefix) { }

        protected override NodeStatus CompletionStatus => NodeStatus.Success;

        protected override bool ShouldContinueOnStatus(NodeStatus status) => status == NodeStatus.Success;
    }
}
