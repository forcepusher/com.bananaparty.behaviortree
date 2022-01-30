namespace BananaParty.BehaviorTree
{
    public class ConstantRollbackNode : ConstantNode, IRollbackNode
    {
        public ConstantRollbackNode(BehaviorNodeStatus statusToReturn) : base(statusToReturn) { }

        public void WriteState(ISnapshotTree snapshotTree)
        {
            snapshotTree.Write(new NodeSnapshot(this, Status));
        }
    }
}
