namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// A chain link that provides parallel chain logic.
    /// </summary>
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
            BehaviorNodeStatus result = PassNext(BehaviorNodeStatus.Running);
            var resultState = _inverted ? BehaviorNodeStatus.Success : BehaviorNodeStatus.Failure;
            return result == resultState ? resultState : BehaviorNodeStatus.Running;
        }
    }
}
