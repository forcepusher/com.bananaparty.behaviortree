namespace BananaParty.BehaviorTree.Rollback
{
    public class ConstantRollbackNode : ConstantNode, IRollbackBehaviorNode<StatelessNodeSnapshot>
    {
        public ConstantRollbackNode(BehaviorNodeStatus statusToReturn) : base(statusToReturn) { }

        public StatelessNodeSnapshot Save()
        {
            return new StatelessNodeSnapshot(Status);
        }

        public void Restore(StatelessNodeSnapshot snapshot)
        {
            Status = snapshot.Status;
        }
    }
}
