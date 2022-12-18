namespace BananaParty.BehaviorTree
{
    public class RollbackSequenceNode : RollbackChainHandlerNode
    {
        protected override bool IsContinuous => _isContinuous;

        protected override BehaviorNodeType Type => BehaviorNodeType.Sequence;

        private readonly bool _isContinuous;

        public RollbackSequenceNode(IRollbackChainNode[] childNodes, bool isContinuous = false)
            : base(childNodes)
        {
            _isContinuous = isContinuous;
        }

        private RollbackSequenceNode(IRollbackChainNode chain, BehaviorNodeStatus status,
            bool isContinuous = false)
        {
            _state = status;
            _chain = chain;
            _isContinuous = isContinuous;
        }

        protected override IRollbackChainNode InstantiateChainNode(IRollbackChainNode node)
        {
            return new RollbackSequenceChainNode(node, false);
        }

        public override IRollbackNode Clone()
        {
            return new RollbackSequenceNode(_chain.Clone(), _state, IsContinuous);
        }
    }
}
