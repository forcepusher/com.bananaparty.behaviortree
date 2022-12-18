namespace BananaParty.BehaviorTree
{
    public class RollbackSequenceChainNode : RollbackChainNode
    {
        protected override bool Inverted => _inverted;
        protected override IRollbackChainNode HandledNode => _handledNode;

        private readonly bool _inverted;
        private readonly IRollbackChainNode _handledNode;

        public RollbackSequenceChainNode(IRollbackChainNode handledNode, bool inverted)
        {
            _handledNode = handledNode;
            _inverted = inverted;
        }

        private RollbackSequenceChainNode(IRollbackChainNode handledNode, bool inverted,
            BehaviorNodeStatus status)
        {
            _handledNode = handledNode;
            _inverted = inverted;
            _state = status;
        }

        public override IRollbackChainNode Clone()
        {
            return new RollbackSequenceChainNode(_handledNode.Clone(), _inverted, _state);
        }

        protected override BehaviorNodeStatus OnRunning()
        {
            return BehaviorNodeStatus.Running;
        }
    }
}
