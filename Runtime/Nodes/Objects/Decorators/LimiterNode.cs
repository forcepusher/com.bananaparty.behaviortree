namespace BananaParty.BehaviorTree
{
    public class LimiterNode : DecoratorNode
    {
        protected override string Name => "Limiter Node";

        private int _repetitionCount;
        private int _currentCount = 0;

        /// <summary>
        /// Allows the child node to be executed the specified <paramref name="repetitionCount"/> of times, returning a value of Running.
        /// </summary>
        public LimiterNode(IBehaviorNode childNode, int repetitionCount = 1) : base(childNode)
        {
            _repetitionCount = repetitionCount > 0 ? repetitionCount : 1;
        }

        protected override BehaviorNodeStatus OnRunning()
        {
            if (_currentCount >= _repetitionCount) return base.OnFailure();
            return base.OnRunning();
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            _currentCount++;
            return _currentCount >= _repetitionCount ? base.OnExecute() : BehaviorNodeStatus.Running;
        }

        protected override void OnRestart()
        {
            _currentCount = 0;
            base.OnRestart();
        }
    }
}
