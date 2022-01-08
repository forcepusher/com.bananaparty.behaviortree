namespace BehaviorTree.Rollback
{
    public class ConstantRollbackNode : ConstantNode, IRollbackBehaviorNode
    {
        public ConstantRollbackNode(BehaviorNodeStatus statusToReturn) : base(statusToReturn) { }

        public IBehaviorNodeSnapshot Save() { return new EmptyNodeSnapshot(); }

        public void Restore(IBehaviorNodeSnapshot snapshot) { }
    }
}
