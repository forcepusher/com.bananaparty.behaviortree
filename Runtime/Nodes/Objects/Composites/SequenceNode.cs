namespace BananaParty.BehaviorTree
{
    public class SequenceNode : ChainHandlerNode
    {
        protected override bool IsContinuous => _isContinuous;

        protected override BehaviorNodeType Type => BehaviorNodeType.Sequence;

        private readonly bool _isContinuous;

        public SequenceNode(IBehaviorNode[] childNodes, bool isContinuous = false) : base(childNodes)
        {
            _isContinuous = isContinuous;
        }

        protected override IChainNode InstantiateChainNode(IBehaviorNode node)
        {
            return new SequenceChainNode(node, false);
        }
    }
}
