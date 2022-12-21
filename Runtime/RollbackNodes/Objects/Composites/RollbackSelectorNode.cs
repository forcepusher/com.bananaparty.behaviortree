namespace BananaParty.BehaviorTree
{
    public class RollbackSelectorNode : RollbackChainHandlerNode
    {
        protected override bool IsContinuous => _isContinuous;

        protected override BehaviorNodeType Type => BehaviorNodeType.Selector;

        private readonly bool _isContinuous;

        public RollbackSelectorNode(IRollbackNode[] childNodes, bool isContinuous = false)
            : base(childNodes)
        {
            _isContinuous = isContinuous;
        }

        private RollbackSelectorNode(IRollbackChainNode chain, BehaviorNodeStatus status,
            bool isContinuous = false)
        {
            _state = status;
            _chain = chain;
            _isContinuous = isContinuous;
        }

        protected override IRollbackChainNode InstantiateChainNode(IRollbackNode node)
        {
            return new RollbackSequenceChainNode(node, true);
        }

        public override IRollbackNode Clone()
        {
            return new RollbackSelectorNode(_chain.Clone(), _state, IsContinuous);
        }
    }
}
