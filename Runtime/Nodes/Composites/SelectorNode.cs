namespace BananaParty.BehaviorTree
{
    public class SelectorNode : SequentialCompositeNode
    {
        public SelectorNode(IBehaviorNode[] childNodes, bool alwaysReevaluate = false, string descriptionPrefix = "") : base(childNodes, alwaysReevaluate, descriptionPrefix) { }

        protected override BehaviorNodeStatus ContinueStatus => BehaviorNodeStatus.Failure;
    }
}
