namespace BananaParty.BehaviorTree
{
    public class Sequence : SequentialComposite
    {
        public Sequence(INode[] childNodes, string descriptionPrefix = "") : base(childNodes, descriptionPrefix) { }

        protected override NodeStatus ContinueStatus => NodeStatus.Success;

        protected override bool IsReactive => false;
    }
}
