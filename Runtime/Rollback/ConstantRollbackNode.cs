namespace BehaviorTree.Rollback
{
    public class ConstantRollbackNode : ConstantNode, IRollbackBehaviorNode
    {
        public ConstantRollbackNode(NodeExecutionStatus statusToReturn) : base(statusToReturn) { }

        public void Restore(ISnapshot snapshot) { }

        public ISnapshot Save() { return new EmptySnapshot(); }
    }
}
