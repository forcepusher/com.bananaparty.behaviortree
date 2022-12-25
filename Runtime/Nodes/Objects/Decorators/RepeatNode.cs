namespace BananaParty.BehaviorTree
{
    public class RepeatNode : DecoratorNode
    {
        private readonly BehaviorNodeFinishStatus _stopStatus;

        /// <summary>
        /// Until the child node returns a <paramref name="stopStatus"/>, returns Running.
        /// </summary>
        public RepeatNode(IBehaviorNode childNode, BehaviorNodeFinishStatus stopStatus) : base(childNode)
        {
            _stopStatus = stopStatus;
        }

        protected override BehaviorNodeStatus OnSuccess()
        {
            if (_stopStatus == BehaviorNodeFinishStatus.Failure)
                return BehaviorNodeStatus.Running;
            return base.OnSuccess();
        }

        protected override BehaviorNodeStatus OnFailure()
        {
            if (_stopStatus == BehaviorNodeFinishStatus.Success)
                return BehaviorNodeStatus.Running;
            return base.OnFailure();
        }
    }
}
