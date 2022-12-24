using System.Text.RegularExpressions;

namespace BananaParty.BehaviorTree
{
    public abstract class BehaviorNode : IBehaviorNode
    {
        protected BehaviorNodeStatus _state = BehaviorNodeStatus.Idle;
        private bool IsNotFinished => (int)_state < 2;
        protected virtual BehaviorNodeType Type => BehaviorNodeType.Leaf;
        protected virtual string Name => CalculateName(Type.ToString());

        private string _calculatedName = string.Empty;

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

        private BehaviorNodeStatus PublishFinishedState()
        {
            return _state switch
            {
                BehaviorNodeStatus.Success => OnSuccess(),
                BehaviorNodeStatus.Failure => OnFailure(),
                _ => OnRunning(),
            };
        }

        private string CalculateName(string name)
        {
            if (string.IsNullOrEmpty(_calculatedName))
            {
                string pattern = "([a-z])([A-Z])";
                string replacement = "$1 $2";
                _calculatedName = Regex.Replace(name, pattern, replacement);
            }
            return _calculatedName;
        }
    }
}
