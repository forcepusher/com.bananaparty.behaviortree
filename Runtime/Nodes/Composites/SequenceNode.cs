namespace BananaParty.BehaviorTree
{
    public class SequenceNode : SequentialCompositeNode
    {
        public SequenceNode(IBehaviorNode[] childNodes, bool isReactive = false, string descriptionPrefix = "") : base(childNodes, isReactive, descriptionPrefix) { }

        protected override BehaviorNodeStatus ContinueStatus => BehaviorNodeStatus.Success;
    }
}
