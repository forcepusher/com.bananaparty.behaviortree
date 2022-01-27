namespace BananaParty.BehaviorTree.Rollback
{
    public interface IBehaviorNodeSnapshot
    {
        public BehaviorNodeStatus Status { get; }
    }
}
