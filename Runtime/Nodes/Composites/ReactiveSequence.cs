namespace BananaParty.BehaviorTree
{
    public class ReactiveSequence : SequentialComposite
    {
        public ReactiveSequence(INode[] childNodes, string descriptionPrefix = "") : base(childNodes, descriptionPrefix) { }

        protected override NodeStatus ContinueStatus => NodeStatus.Success;

        protected override bool IsReactive => true;
    }
}
