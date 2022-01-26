namespace BananaParty.BehaviorTree
{
    public class SequenceNode : SequentialCompositeNode
    {
        public SequenceNode(IBehaviorNode[] childNodes, bool alwaysReevaluate = false, string descriptionPrefix = "") : base(childNodes, alwaysReevaluate, descriptionPrefix) { }

        protected override BehaviorNodeStatus ContinueStatus => BehaviorNodeStatus.Success;
    }
}
