namespace BananaParty.BehaviorTree
{
    public class ConstantNode : BehaviorNode
    {
        private readonly BehaviorNodeStatus _statusToReturn;

        public ConstantNode(BehaviorNodeStatus statusToReturn)
        {
            _statusToReturn = statusToReturn;
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            return (int)_statusToReturn > 1 ? _statusToReturn : BehaviorNodeStatus.Success;
        }
    }
}
