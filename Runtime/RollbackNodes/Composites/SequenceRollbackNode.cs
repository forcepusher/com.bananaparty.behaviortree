namespace BananaParty.BehaviorTree
{
    public class SequenceRollbackNode : SequenceNode, IRollbackNode
    {
        private readonly IRollbackNode[] _childNodes;

        public SequenceRollbackNode(IRollbackNode[] childNodes, bool alwaysReevaluate = false, string descriptionPrefix = "") : base(childNodes, alwaysReevaluate, descriptionPrefix)
        {
            _childNodes = childNodes;
        }

        public void SaveState(ISnapshotTree snapshotTree)
        {
            snapshotTree.Write(new SequenceNodeSnapshot(this, Status));

            foreach (IRollbackNode child in _childNodes)
                child.SaveState(snapshotTree);
        }
    }
}
