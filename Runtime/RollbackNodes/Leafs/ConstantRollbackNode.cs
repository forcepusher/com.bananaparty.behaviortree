namespace BananaParty.BehaviorTree
{
    public class ConstantRollbackNode : ConstantNode, IRollbackNode
    {
        private readonly BehaviorNodeStatus _statusToReturn;
        
        public ConstantRollbackNode(BehaviorNodeStatus statusToReturn) : base(statusToReturn)
        {
            _statusToReturn = statusToReturn;
        }

        public IRollbackNode Copy()
        {
            var nodeCopy = new ConstantRollbackNode(_statusToReturn);
            nodeCopy.Status = Status;
            
            return nodeCopy;
        }
    }
}
