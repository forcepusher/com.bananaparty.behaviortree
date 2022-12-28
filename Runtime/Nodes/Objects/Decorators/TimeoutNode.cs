namespace BananaParty.BehaviorTree
{
    public class TimeoutNode : DecoratorNode
    {
        protected override string Name => "Timeout Node";

        private readonly ITimer _timer;

        /// <summary>
        /// When executed, starts the specified <paramref name="timer"/>. If the timer has completed its work, then the child node executes.
        /// </summary>
        public TimeoutNode(IBehaviorNode childNode, ITimer timer) : base(childNode)
        {
            _timer = timer;
        }

        protected override BehaviorNodeStatus OnRunning()
        {
            if (_timer.IsEnded()) _timer.Reset();
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
