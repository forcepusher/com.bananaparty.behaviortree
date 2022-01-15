namespace BananaParty.BehaviorTree
{
    public class SelectorNode : SequentialCompositeNode
    {
        public SelectorNode(IBehaviorNode[] childNodes, bool alwaysReevaluate = false) : base(childNodes, alwaysReevaluate) { }

        protected override BehaviorNodeStatus ContinueStatus => BehaviorNodeStatus.Failure;
    }
}
