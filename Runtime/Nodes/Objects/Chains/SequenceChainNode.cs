namespace BananaParty.BehaviorTree
{
    public class SequenceChainNode : ChainNode
    {
        protected override bool Inverted => _inverted;
        protected override IBehaviorNode HandledNode => _handledNode;

        private readonly bool _inverted;
        private readonly IBehaviorNode _handledNode;

        public SequenceChainNode(IBehaviorNode handledNode, bool inverted)
        {
            _handledNode = handledNode;
            _inverted = inverted;
        }

        protected override BehaviorNodeStatus OnRunning()
        {
            return BehaviorNodeStatus.Running;
        }
    }
}
