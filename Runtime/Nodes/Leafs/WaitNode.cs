namespace BananaParty.BehaviorTree
{
    public class WaitNode : BehaviorNode
    {
        private readonly long _duration;

        private long _startTime = -1;

        public WaitNode(long duration)
        {
            _duration = duration;
        }

        public override string Name => $"{base.Name} {_duration}";

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (Status == BehaviorNodeStatus.Idle)
                _startTime = time;

            if (time < _startTime + _duration)
                return BehaviorNodeStatus.Running;
            else
                return BehaviorNodeStatus.Success;
        }

        public override void OnReset()
        {
            _startTime = -1;
        }
    }
}
