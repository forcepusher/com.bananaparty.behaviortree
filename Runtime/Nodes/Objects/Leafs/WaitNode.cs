using System.Diagnostics;

namespace BananaParty.BehaviorTree
{
    public class WaitNode : BehaviorNode
    {
        private readonly ITimer _timer;

        public WaitNode(ITimer timer)
        {
            _timer = timer;
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            _timer.Start();
            return _timer.IsEnded() ? BehaviorNodeStatus.Success : BehaviorNodeStatus.Running;
        }

        protected override void OnRestart()
        {
            _timer.Reset();
            base.OnRestart();
        }
    }
}
