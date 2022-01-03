namespace BehaviorTree.Rollback
{
    public class ConstantRollbackNode : ConstantNode, IRollbackBehaviorNode
    {
        public ConstantRollbackNode(NodeExecutionStatus statusToReturn) : base(statusToReturn) { }

        public ISnapshot Save() { return new EmptySnapshot(); }

        public void Restore(ISnapshot snapshot) { }
    }
}
