namespace BananaParty.BehaviorTree
{
    public class Wait : Node
    {
        private readonly float _duration;

        private float _accumulatedTime = 0f;

        public Wait(float duration)
        {
            _duration = duration;
        }

        public override string Name => $"{base.Name} {_duration}";

        public override NodeStatus OnExecute(float deltaTime)
        {
            _accumulatedTime += deltaTime;

            if (_accumulatedTime < _duration)
                return NodeStatus.Running;
            else
                return NodeStatus.Success;
        }

        public override void OnReset()
        {
            _accumulatedTime = 0f;
        }
    }
}
