namespace BananaParty.BehaviorTree
{
    public class ConstantNode : BehaviorNode
    {
        private readonly BehaviorNodeStatus _statusToReturn;

        public ConstantNode(BehaviorNodeStatus statusToReturn)
        {
            _statusToReturn = statusToReturn;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            return _statusToReturn;
        }
    }
}
