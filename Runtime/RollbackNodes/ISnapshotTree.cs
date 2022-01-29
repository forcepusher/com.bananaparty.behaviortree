namespace BananaParty.BehaviorTree
{
    public interface ISnapshotTree : INodeSnapshot
    {
        public void Write(INodeSnapshot nodeSnapshot);
    }
}
