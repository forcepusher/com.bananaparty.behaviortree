namespace BananaParty.BehaviorTree
{
    public class RepeatNode : DecoratorNode
    {
        private readonly BehaviorNodeStatus? _stopStatus;

        public RepeatNode(IBehaviorNode childNode, BehaviorNodeStatus stopStatus) : base(childNode)
        {
            _stopStatus = stopStatus;
        }

        protected override BehaviorNodeStatus OnSuccess()
        {
            if (_stopStatus == BehaviorNodeStatus.Failure)
                return BehaviorNodeStatus.Running;
            return base.OnSuccess();
        }

        protected override BehaviorNodeStatus OnFailure()
        {
            if (_stopStatus == BehaviorNodeStatus.Success)
                return BehaviorNodeStatus.Running;
            return base.OnFailure();
        }
    }
}
