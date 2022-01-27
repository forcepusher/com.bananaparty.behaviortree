namespace BananaParty.BehaviorTree.Rollback
{
    public class SequenceNodeSnapshot : IBehaviorNodeSnapshot
    {
        public readonly IBehaviorNodeSnapshot[] ChildSnapshots;

        public BehaviorNodeStatus Status { get; }

        public SequenceNodeSnapshot(BehaviorNodeStatus status, IBehaviorNodeSnapshot[] childSnapshots)
        {
            Status = status;
            ChildSnapshots = childSnapshots;
        }
    }
}
