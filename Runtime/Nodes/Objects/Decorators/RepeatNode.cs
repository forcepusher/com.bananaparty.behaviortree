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
            if (_stopStatus == BehaviorNodeFinishStatus.Success)
                return base.OnSuccess();
            Restart();
            return BehaviorNodeStatus.Running;
        }

        protected override BehaviorNodeStatus OnFailure()
        {
            if (_stopStatus == BehaviorNodeFinishStatus.Failure)
                return base.OnFailure();
            Restart();
            return BehaviorNodeStatus.Running;
        }
    }
}
