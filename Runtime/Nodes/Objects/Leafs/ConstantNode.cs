namespace BananaParty.BehaviorTree
{
    public class ConstantNode : BehaviorNode
    {
        protected readonly BehaviorNodeStatus _statusToReturn;

        public ConstantNode(BehaviorNodeStatus statusToReturn)
        {
            _statusToReturn = statusToReturn;
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            return (int)_statusToReturn > 0 ? _statusToReturn : BehaviorNodeStatus.Success;
        }
    }
}
