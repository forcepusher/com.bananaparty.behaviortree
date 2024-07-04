namespace BananaParty.BehaviorTree
{
    public class Selector : SequentialComposite
    {
        public Selector(INode[] childNodes, string descriptionPrefix = "") : base(childNodes, descriptionPrefix) { }

        protected override NodeStatus ContinueStatus => NodeStatus.Failure;

        protected override bool IsReactive => false;
    }
}
