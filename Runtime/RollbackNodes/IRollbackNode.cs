namespace BananaParty.BehaviorTree
{
    public interface IRollbackNode : IBehaviorNode
    {
        void SaveState(ISnapshotTree snapshotTree);
    }
}
