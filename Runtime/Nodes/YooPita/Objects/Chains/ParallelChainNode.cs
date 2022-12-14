namespace YooPita.BT
{
    public class ParallelChainNode : ChainNode
    {
        protected override bool Inverted => _inverted;
        protected override IBehaviorNode HandledNode => _handledNode;

        private readonly bool _inverted;
        private readonly IBehaviorNode _handledNode;

        public ParallelChainNode(IBehaviorNode handledNode, bool inverted)
        {
            _handledNode = handledNode;
            _inverted = inverted;
        }

        protected override BehaviorNodeStatus OnRunning()
        {
            BehaviorNodeStatus result = PassNext();
            return result == BehaviorNodeStatus.Failure ? BehaviorNodeStatus.Failure : BehaviorNodeStatus.Running;
        }
    }
}
