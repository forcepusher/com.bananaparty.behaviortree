namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// Still a sequence that executes sequentially, but multiple nodes can enter running state.
    /// </summary>
    public class ParallelSequenceNode : ParallelCompositeNode
    {
        public ParallelSequenceNode(IBehaviorNode[] childNodes, string descriptionPrefix = "") : base(childNodes, descriptionPrefix) { }

        protected override BehaviorNodeStatus ContinueStatus => BehaviorNodeStatus.Success;
    }
}
