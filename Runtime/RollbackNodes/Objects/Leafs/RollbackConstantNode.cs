namespace BananaParty.BehaviorTree
{
    public class RollbackConstantNode : ConstantNode, IRollbackNode
    {
        public RollbackConstantNode(BehaviorNodeStatus statusToReturn) : base(statusToReturn) { }

        public IRollbackNode Clone()
        {
            return new RollbackConstantNode(_statusToReturn);
        }
    }
}
