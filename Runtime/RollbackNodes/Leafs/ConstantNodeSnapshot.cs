namespace BananaParty.BehaviorTree
{
    public class ConstantNodeSnapshot : INodeSnapshot
    {
        private readonly ConstantNode _constantNode;
        private readonly BehaviorNodeStatus _status;

        public ConstantNodeSnapshot(ConstantNode constantNode, BehaviorNodeStatus status)
        {
            _constantNode = constantNode;
            _status = status;
        }

        public void ApplyState()
        {
            _constantNode.Status = _status;
        }
    }
}
