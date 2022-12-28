namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// A chain link that provides first complete chain logic.
    /// </summary>
    public class ParallelFirstCompleteChainNode : ChainNode
    {
        protected override string Name => "Parallel First Complete Chain Node";

        protected override bool Inverted => false;

        private readonly bool _inverted;

        public ParallelFirstCompleteChainNode(IBehaviorNode childNode) : base(childNode) { }

        protected override BehaviorNodeStatus OnSuccess()
        {
            return BehaviorNodeStatus.Success;
        }

        protected override BehaviorNodeStatus OnFailure()
        {
            return BehaviorNodeStatus.Failure;
        }

        protected override BehaviorNodeStatus OnRunning()
        {
            BehaviorNodeStatus result = PassNext(BehaviorNodeStatus.Running);
            return (int)result > 1 ? result : BehaviorNodeStatus.Running;
        }
    }
}
