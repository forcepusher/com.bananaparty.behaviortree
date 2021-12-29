namespace BehaviorTree.Rollback
{
    public readonly struct SequenceNodeSnapshot : ISnapshot
    {
        public readonly int RunningChildNodeIndex;
        public readonly ISnapshot[] ChildSnapshots;

        public SequenceNodeSnapshot(int runningChildNodeIndex, ISnapshot[] childSnapshots)
        {
            RunningChildNodeIndex = runningChildNodeIndex;
            ChildSnapshots = childSnapshots;
        }
    }
}
