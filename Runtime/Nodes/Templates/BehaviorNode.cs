namespace BananaParty.BehaviorTree
{
    public abstract class BehaviorNode : IBehaviorNode
    {
        private bool IsNotFinished => (int)_state < 2;

        protected BehaviorNodeStatus _state = BehaviorNodeStatus.Idle;

        public BehaviorNodeStatus Execute()
        {
            if (IsNotFinished)
                _state = OnExecute();
            return PublishFinishedState();
        }

        public void Restart()
        {
            _state = BehaviorNodeStatus.Idle;
            OnRestart();
        }

        protected virtual void OnRestart() { }

        protected virtual BehaviorNodeStatus OnSuccess() => BehaviorNodeStatus.Success;

        protected virtual BehaviorNodeStatus OnFailure() => BehaviorNodeStatus.Failure;

        protected virtual BehaviorNodeStatus OnRunning() => BehaviorNodeStatus.Running;

        protected abstract BehaviorNodeStatus OnExecute();

        private BehaviorNodeStatus PublishFinishedState()
        {
            return _state switch
            {
                BehaviorNodeStatus.Success => OnSuccess(),
                BehaviorNodeStatus.Failure => OnFailure(),
                _ => OnRunning(),
            };
        }
    }
}
