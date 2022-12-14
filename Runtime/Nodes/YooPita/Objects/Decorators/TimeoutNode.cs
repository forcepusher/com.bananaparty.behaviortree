namespace YooPita.BT
{
    public class TimeoutNode : DecoratorNode
    {
        private readonly ITimer _timer;

        public TimeoutNode(IBehaviorNode childNode, ITimer timer) : base(childNode)
        {
            _timer = timer;
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            _timer
            return base.OnExecute();
        }
    }
}
