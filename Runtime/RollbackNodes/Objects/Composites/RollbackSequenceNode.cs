namespace BananaParty.BehaviorTree
{
    public class RollbackSequenceNode : RollbackChainHandlerNode
    {
        protected override string Name => "Rollback Sequence Node";

        protected override BehaviorNodeType Type => BehaviorNodeType.Sequence;

        public RollbackSequenceNode(IRollbackNode[] childNodes, bool isContinuous = true)
            : base(childNodes, isContinuous)
        {
        }

        private RollbackSequenceNode(IRollbackChainNode chain, BehaviorNodeStatus status,
            bool isContinuous = true)
        {
            _state = status;
            _chain = chain;
        }

        protected override IRollbackChainNode InstantiateChainNode(IRollbackNode node)
        {
            return new RollbackSequenceChainNode(node, false, IsContinuous);
        }

        public override IRollbackNode Clone()
        {
            return new RollbackSequenceNode(_chain.Clone(), _state, IsContinuous);
        }
    }
}
