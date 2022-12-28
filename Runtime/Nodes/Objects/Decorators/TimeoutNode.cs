namespace BananaParty.BehaviorTree
{
    public class TimeoutNode : DecoratorNode
    {
        protected override string Name => "Timeout Node";

        private readonly ITimer _timer;

        /// <summary>
        /// Executes the node while the <paramref name="timer"/> is running.
        /// If the <paramref name="timer"/> has expired and the node has not
        /// returned anything other than Running, then it returns a Failure.
        /// </summary>
        public TimeoutNode(IBehaviorNode childNode, ITimer timer) : base(childNode)
        {
            _timer = timer;
        }

        protected override BehaviorNodeStatus OnRunning()
        {
            if (_timer.IsEnded()) return BehaviorNodeStatus.Failure;
            return base.OnRunning();
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            _timer.StartIfNot();
            return _timer.IsEnded() ? base.OnExecute() : BehaviorNodeStatus.Running;
        }

        protected override void OnRestart()
        {
            _timer.Reset();
            base.OnRestart();
        }
    }
}
