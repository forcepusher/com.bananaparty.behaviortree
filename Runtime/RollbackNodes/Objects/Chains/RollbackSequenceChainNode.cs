namespace BananaParty.BehaviorTree
{
    public class RollbackSequenceChainNode : RollbackChainNode
    {
        protected override bool Inverted => _inverted;

        private readonly bool _inverted;

        public RollbackSequenceChainNode(IRollbackNode childNode, bool inverted) : base(childNode)
        {
            _inverted = inverted;
        }

        private RollbackSequenceChainNode(IRollbackNode childNode, IRollbackChainNode nextNode,
            bool inverted, BehaviorNodeStatus status) : base(childNode, nextNode)
        {
            _inverted = inverted;
            _state = status;
        }

        public override IRollbackChainNode Clone()
        {
            return new RollbackSequenceChainNode(CloneChild(), CloneNextNode(), _inverted, _state);
        }

        protected override BehaviorNodeStatus OnRunning()
        {
            return BehaviorNodeStatus.Running;
        }
    }
}
