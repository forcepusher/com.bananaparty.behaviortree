namespace BananaParty.BehaviorTree
{
    public interface IRollbackNode : IBehaviorNode
    {
        void WriteState(ISnapshotTree snapshotTree);

        /// <summary>
        /// Current execution state. Setter is enabled for implementing rollback.
        /// </summary>
        new BehaviorNodeStatus Status { get; set; }
    }
}
