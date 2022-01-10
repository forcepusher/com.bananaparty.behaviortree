namespace BananaParty.BehaviorTree.Rollback
{
    public readonly struct SequenceNodeSnapshot : IBehaviorNodeSnapshot
    {
        public readonly BehaviorNodeStatus Status;
        public readonly IBehaviorNodeSnapshot[] ChildSnapshots;

        public SequenceNodeSnapshot(BehaviorNodeStatus status, IBehaviorNodeSnapshot[] childSnapshots)
        {
            Status = status;
            ChildSnapshots = childSnapshots;
        }
    }
}
