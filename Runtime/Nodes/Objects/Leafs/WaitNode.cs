namespace BananaParty.BehaviorTree
{
    public class WaitNode : BehaviorNode
    {
        protected override string Name => "Wait Node";

        private readonly ITimer _timer;

        /// <summary>
        /// Waits until the <paramref name="timer"/> expires. Returns Success on completion.
        /// </summary>
        public WaitNode(ITimer timer)
        {
            _timer = timer;
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            _timer.StartIfNot();
            return _timer.IsEnded() ? BehaviorNodeStatus.Success : BehaviorNodeStatus.Running;
        }

        protected override void OnRestart()
        {
            _timer.Reset();
            base.OnRestart();
        }
    }
}
