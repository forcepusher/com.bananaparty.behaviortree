namespace BananaParty.BehaviorTree
{
    public class RollbackSelectorNode : RollbackChainHandlerNode
    {
        protected override string Name => "Rollback Selector Node";

        protected override BehaviorNodeType Type => BehaviorNodeType.Selector;

        public RollbackSelectorNode(IRollbackNode[] childNodes, bool isContinuous = true)
            : base(childNodes, isContinuous)
        {
        }

        private RollbackSelectorNode(IRollbackChainNode chain, BehaviorNodeStatus status,
            bool isContinuous = true)
        {
            _state = status;
            _chain = chain;
        }

        protected override IRollbackChainNode InstantiateChainNode(IRollbackNode node)
        {
            return new RollbackSequenceChainNode(node, true, IsContinuous);
        }

        public override IRollbackNode Clone()
        {
            return new RollbackSelectorNode(_chain.Clone(), _state, IsContinuous);
        }
    }
}
