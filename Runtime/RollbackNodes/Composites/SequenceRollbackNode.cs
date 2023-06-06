namespace BananaParty.BehaviorTree
{
    public class SequenceRollbackNode : SequenceNode, IRollbackNode
    {
        private readonly IRollbackNode[] _childNodes;

        public SequenceRollbackNode(IRollbackNode[] childNodes, string descriptionPrefix = "") : base(childNodes, descriptionPrefix)
        {
            _childNodes = childNodes;
        }

        public void WriteState(ISnapshotTree snapshotTree)
        {
            snapshotTree.Write(new NodeStatusSnapshot(this, Status));

            foreach (IRollbackNode child in _childNodes)
                child.WriteState(snapshotTree);
        }
    }
}
