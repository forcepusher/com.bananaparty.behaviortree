namespace BehaviorTree.Rollback
{
    public struct StatusNodeSnapshot : IBehaviorNodeSnapshot
    {
        public readonly NodeExecutionStatus Status;

        public StatusNodeSnapshot(NodeExecutionStatus status)
        {
            Status = status;
        }
    }
}
