namespace BananaParty.BehaviorTree
{
    public class ReactiveSelectorNode : SequentialCompositeNode
    {
        public ReactiveSelectorNode(IBehaviorNode[] childNodes, string descriptionPrefix = "") : base(childNodes, descriptionPrefix) { }

        protected override BehaviorNodeStatus ContinueStatus => BehaviorNodeStatus.Failure;

        protected override bool IsReactive => true;
    }
}
