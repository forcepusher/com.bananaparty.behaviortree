namespace BananaParty.BehaviorTree
{
    public class SequenceNode : SequentialCompositeNode
    {
        public SequenceNode(IBehaviorNode[] childNodes, bool alwaysReevaluate = false) : base(childNodes, alwaysReevaluate) { }

        protected override BehaviorNodeStatus ContinueStatus => BehaviorNodeStatus.Success;
    }
}
