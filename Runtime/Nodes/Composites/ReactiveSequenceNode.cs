namespace BananaParty.BehaviorTree
{
    public class ReactiveSequenceNode : SequentialCompositeNode
    {
        public ReactiveSequenceNode(IBehaviorNode[] childNodes, string descriptionPrefix = "") : base(childNodes, descriptionPrefix) { }

        protected override BehaviorNodeStatus ContinueStatus => BehaviorNodeStatus.Success;

        protected override bool IsReactive => true;
    }
}
