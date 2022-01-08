namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// Still a selector that executes sequentially, but multiple nodes can enter running state.
    /// </summary>
    public class ParallelSelectorNode : ParallelCompositeNode
    {
        public ParallelSelectorNode(IBehaviorNode[] childNodes) : base(childNodes) { }

        protected override BehaviorNodeStatus ContinueStatus => BehaviorNodeStatus.Failure;
    }
}
