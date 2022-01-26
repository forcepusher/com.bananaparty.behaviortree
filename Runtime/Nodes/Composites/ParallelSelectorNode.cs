namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// Still a selector that executes sequentially, but multiple nodes can enter running state.
    /// </summary>
    public class ParallelSelectorNode : ParallelCompositeNode
    {
        public ParallelSelectorNode(IBehaviorNode[] childNodes, string descriptionPrefix = "") : base(childNodes, descriptionPrefix) { }

        protected override BehaviorNodeStatus ContinueStatus => BehaviorNodeStatus.Failure;
    }
}
