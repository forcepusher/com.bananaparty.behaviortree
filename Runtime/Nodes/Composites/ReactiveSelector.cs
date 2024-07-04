namespace BananaParty.BehaviorTree
{
    public class ReactiveSelector : SequentialComposite
    {
        public ReactiveSelector(INode[] childNodes, string descriptionPrefix = "") : base(childNodes, descriptionPrefix) { }

        protected override NodeStatus ContinueStatus => NodeStatus.Failure;

        protected override bool IsReactive => true;
    }
}
