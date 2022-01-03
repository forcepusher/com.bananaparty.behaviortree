namespace BehaviorTree.Rollback
{
    public readonly struct SequenceNodeSnapshot : IBehaviorNodeSnapshot
    {
        public readonly NodeExecutionStatus Status;
        public readonly IBehaviorNodeSnapshot[] ChildSnapshots;

        public SequenceNodeSnapshot(NodeExecutionStatus status, IBehaviorNodeSnapshot[] childSnapshots)
        {
            Status = status;
            ChildSnapshots = childSnapshots;
        }
    }
}
