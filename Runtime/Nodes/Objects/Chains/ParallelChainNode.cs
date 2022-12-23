namespace BananaParty.BehaviorTree
{
    public class ParallelChainNode : ChainNode
    {
        protected override bool Inverted => _inverted;

        private readonly bool _inverted;

        public ParallelChainNode(IBehaviorNode childNode, bool inverted) : base(childNode)
        {
            _inverted = inverted;
        }

        protected override BehaviorNodeStatus OnRunning()
        {
            BehaviorNodeStatus result = PassNext();
            return result == BehaviorNodeStatus.Failure ? BehaviorNodeStatus.Failure : BehaviorNodeStatus.Running;
        }
    }
}
