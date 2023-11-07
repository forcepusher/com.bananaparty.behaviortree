namespace BananaParty.BehaviorTree
{
    public class EventNode : BehaviorNode
    {
        private bool _isLocked;
        private bool _trigger;

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_trigger)
            {
                _trigger = false;
                return BehaviorNodeStatus.Success;
            }

            return BehaviorNodeStatus.Failure;
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
