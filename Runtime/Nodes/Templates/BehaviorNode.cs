namespace BananaParty.BehaviorTree
{
    public abstract class BehaviorNode : IBehaviorNode
    {
        protected BehaviorNodeStatus _state = BehaviorNodeStatus.Idle;
        private bool IsNotFinished => (int)_state < 2;
        protected virtual BehaviorNodeType Type => BehaviorNodeType.Leaf;
        protected abstract string Name { get; }

        public BehaviorNodeStatus Execute()
        {
            if (IsNotFinished)
                _state = PublishFinishedState(OnExecute());
            return _state;
        }

        public void Restart()
        {
            if (_state == BehaviorNodeStatus.Idle) return;
            _state = BehaviorNodeStatus.Idle;
            OnRestart();
        }

        public virtual BehaviorNodeVisualizationData GetVisualizationData()
        {
            return new BehaviorNodeVisualizationData()
            {
                Name = Name,
                State = _state,
                Type = Type,
            };
        }

        protected virtual void OnRestart() { }

        protected virtual BehaviorNodeStatus OnSuccess() => BehaviorNodeStatus.Success;

        protected virtual BehaviorNodeStatus OnFailure() => BehaviorNodeStatus.Failure;

        protected virtual BehaviorNodeStatus OnRunning() => BehaviorNodeStatus.Running;

        protected abstract BehaviorNodeStatus OnExecute();

        private BehaviorNodeStatus PublishFinishedState(BehaviorNodeStatus status)
        {
            return status switch
            {
                BehaviorNodeStatus.Success => OnSuccess(),
                BehaviorNodeStatus.Failure => OnFailure(),
                _ => OnRunning(),
            };
        }
    }
}
