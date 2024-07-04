namespace BananaParty.BehaviorTree
{
    public class Constant : Node
    {
        private readonly NodeStatus _statusToReturn;

        public Constant(NodeStatus statusToReturn)
        {
            _statusToReturn = statusToReturn;
        }

        public override NodeStatus OnExecute(float deltaTime)
        {
            return _statusToReturn;
        }

        public override string Name => $"{base.Name}:{_statusToReturn}";
    }
}
