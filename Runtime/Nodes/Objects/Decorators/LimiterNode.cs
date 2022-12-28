namespace BananaParty.BehaviorTree
{
    public class LimiterNode : DecoratorNode
    {
        protected override string Name => "Limiter Node";

        private int _repetitionCount;
        private int _currentCount = 0;

        /// <summary>
        /// Allows the child node to be executed the specified <paramref name="repetitionCount"/> of times, returning a value of Running.
        /// If the node has executed the specified number of times and the node is still Running, it returns Failure.
        /// </summary>
        public LimiterNode(IBehaviorNode childNode, int repetitionCount = 1) : base(childNode)
        {
            _repetitionCount = repetitionCount > 0 ? repetitionCount : 1;
        }

        protected override BehaviorNodeStatus OnSuccess()
        {
            if (_currentCount >= _repetitionCount)
                return base.OnSuccess();
            base.OnRestart();
            return BehaviorNodeStatus.Running;
        }

        protected override BehaviorNodeStatus OnFailure()
        {
            if (_currentCount >= _repetitionCount)
                return base.OnFailure();
            base.OnRestart();
            return BehaviorNodeStatus.Running;
        }

        protected override BehaviorNodeStatus OnRunning()
        {
            if (_currentCount >= _repetitionCount) return base.OnFailure();
            return base.OnRunning();
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            _currentCount++;
            return base.OnExecute();
        }

        protected override void OnRestart()
        {
            _currentCount = 0;
            base.OnRestart();
        }
    }
}
