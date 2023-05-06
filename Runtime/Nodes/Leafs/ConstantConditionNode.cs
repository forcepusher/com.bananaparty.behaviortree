namespace BananaParty.BehaviorTree
{
    public class ConstantConditionNode : ConditionNode
    {
        private readonly BehaviorNodeStatus _statusToReturn;

        public ConstantConditionNode(BehaviorNodeStatus statusToReturn)
        {
            _statusToReturn = statusToReturn;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            return _statusToReturn;
        }

        public override string Name => $"{base.Name}:{_statusToReturn}";
    }
}
