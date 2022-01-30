namespace BananaParty.BehaviorTree
{
    public interface ISnapshotTree : INodeSnapshot
    {
        void Write(INodeSnapshot nodeSnapshot);
    }
}
