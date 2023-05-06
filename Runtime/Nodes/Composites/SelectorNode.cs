namespace BananaParty.BehaviorTree
{
    public class SelectorNode : SequentialCompositeNode
    {
        public SelectorNode(IBehaviorNode[] childNodes, bool isReactive = false, string descriptionPrefix = "") : base(childNodes, isReactive, descriptionPrefix) { }

        protected override BehaviorNodeStatus ContinueStatus => BehaviorNodeStatus.Failure;
    }
}
