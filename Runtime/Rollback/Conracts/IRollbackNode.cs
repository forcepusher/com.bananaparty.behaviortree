namespace BananaParty.BehaviorTree
{
    public interface IRollbackNode : IBehaviorNode
    {
        public IRollbackNode Clone();
        public void Restore();
    }
}
