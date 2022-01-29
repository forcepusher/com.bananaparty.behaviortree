namespace BananaParty.BehaviorTree
{
    public class ConstantRollbackNode : ConstantNode, IRollbackNode
    {
        public ConstantRollbackNode(BehaviorNodeStatus statusToReturn) : base(statusToReturn) { }

        public void SaveState(ISnapshotTree snapshotTree)
        {
            snapshotTree.Write(new ConstantNodeSnapshot(this, Status));
        }
    }
}
