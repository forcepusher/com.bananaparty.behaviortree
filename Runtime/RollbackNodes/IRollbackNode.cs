namespace BananaParty.BehaviorTree
{
    public interface IRollbackNode : IBehaviorNode
    {
        void WriteState(ISnapshotTree snapshotTree);
    }
}
