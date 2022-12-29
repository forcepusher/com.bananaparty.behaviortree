namespace BananaParty.BehaviorTree
{
    public class RollbackSequenceChainNode : RollbackChainNode
    {
        protected override string Name => "Rollback Sequence ChainNode";

        protected override bool Inverted => _inverted;

        private readonly bool _inverted;
        private readonly bool _isContinuous;

        public RollbackSequenceChainNode(IRollbackNode childNode, bool inverted, bool isContinuous) : base(childNode)
        {
            _inverted = inverted;
            _isContinuous = isContinuous;
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
