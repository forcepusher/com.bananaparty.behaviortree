namespace BehaviorTree.Rollback
{
    public struct StatusNodeSnapshot : IBehaviorNodeSnapshot
    {
        public readonly BehaviorNodeStatus Status;

        public StatusNodeSnapshot(BehaviorNodeStatus status)
        {
            Status = status;
        }
    }
}
