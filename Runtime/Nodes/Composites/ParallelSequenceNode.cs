namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// Still a sequence that executes sequentially, but multiple nodes can enter running state.
    /// </summary>
    public class ParallelSequenceNode : ParallelCompositeNode
    {
        public ParallelSequenceNode(IBehaviorNode[] childNodes, string descriptionPrefix = "") : base(childNodes, descriptionPrefix) { }

        protected override BehaviorNodeStatus CompletionStatus => BehaviorNodeStatus.Success;

        protected override bool ShouldContinueOnStatus(BehaviorNodeStatus status) => status == BehaviorNodeStatus.Success;
    }
}
