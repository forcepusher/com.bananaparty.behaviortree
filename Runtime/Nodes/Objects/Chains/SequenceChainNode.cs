namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// A link in a chain that provides consistent chain logic.
    /// </summary>
    public class SequenceChainNode : ChainNode
    {
        protected override string Name => "Sequence Chain Node";

        protected override bool Inverted => _inverted;

        private readonly bool _inverted;
        private readonly bool _isContinuous;

        public SequenceChainNode(IBehaviorNode childNode, bool inverted, bool isContinuous) : base(childNode)
        {
            _inverted = inverted;
            _isContinuous = isContinuous;
        }

        protected override BehaviorNodeStatus OnSuccess()
        {
            if (!Inverted)
                return RestartChildIfNextRunning(PassNext(BehaviorNodeStatus.Success));
            RestartNextNode();
            return BehaviorNodeStatus.Success;
        }

        protected override BehaviorNodeStatus OnFailure()
        {
            if (Inverted)
                return RestartChildIfNextRunning(PassNext(BehaviorNodeStatus.Failure));
            RestartNextNode();
            return BehaviorNodeStatus.Failure;
        }

        protected override BehaviorNodeStatus OnRunning()
        {
            RestartNextNode();
            return base.OnRunning();
        }

        private BehaviorNodeStatus RestartChildIfNextRunning(BehaviorNodeStatus result)
        {
            if (!_isContinuous && result == BehaviorNodeStatus.Running)
                RestartChild();
            return result;
        }
    }
}
