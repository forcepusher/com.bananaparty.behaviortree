namespace BananaParty.BehaviorTree
{
    public class EventTrigger : Node
    {
        private bool _isLocked;
        private bool _trigger;

        public override NodeStatus OnExecute(float deltaTime)
        {
            if (_trigger)
            {
                _trigger = false;
                return NodeStatus.Success;
            }

            return NodeStatus.Failure;
        }

        public void Trigger()
        {
            if (_isLocked)
                return;

            _trigger = true;
        }

        public void Lock()
        {
            _isLocked = true;
        }

        public void Unlock()
        {
            _isLocked = false;
        }
    }
}
