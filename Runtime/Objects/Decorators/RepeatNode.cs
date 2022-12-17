namespace BananaParty.BehaviorTree
{
    public class RepeatNode : DecoratorNode
    {
        private readonly BehaviorNodeResultStatus _stopStatus;

        public RepeatNode(IBehaviorNode childNode, BehaviorNodeResultStatus stopStatus) : base(childNode)
        {
            _stopStatus = stopStatus;
        }

        protected override BehaviorNodeStatus OnSuccess()
        {
            if (_stopStatus == BehaviorNodeResultStatus.Failure)
                return BehaviorNodeStatus.Running;
            return base.OnSuccess();
        }

        protected override BehaviorNodeStatus OnFailure()
        {
            if (_stopStatus == BehaviorNodeResultStatus.Success)
                return BehaviorNodeStatus.Running;
            return base.OnFailure();
        }
    }
}
