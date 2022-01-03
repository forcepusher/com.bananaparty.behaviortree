namespace BehaviorTree.Rollback
{
    public readonly struct SequenceNodeSnapshot : ISnapshot
    {
        public readonly int RunningChildIndex;
        public readonly ISnapshot[] ChildSnapshots;

        public SequenceNodeSnapshot(int runningChildIndex, ISnapshot[] childSnapshots)
        {
            RunningChildIndex = runningChildIndex;
            ChildSnapshots = childSnapshots;
        }
    }
}
