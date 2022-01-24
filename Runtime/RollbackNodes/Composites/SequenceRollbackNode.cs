namespace BananaParty.BehaviorTree.Rollback
{
    public class SequenceRollbackNode : SequenceNode, IRollbackBehaviorNode<SequenceNodeSnapshot>
    {
        private readonly IRollbackBehaviorNode[] _childNodes;

        public SequenceRollbackNode(IRollbackBehaviorNode[] childNodes, bool alwaysReset = false, string descriptionPrefix = "") : base(childNodes, alwaysReset, descriptionPrefix)
        {
            _childNodes = childNodes;
        }

        public SequenceNodeSnapshot Save()
        {
            var snapshots = new IBehaviorNodeSnapshot[_childNodes.Length];
            for (int childIterator = 0; childIterator < _childNodes.Length; childIterator += 1)
                snapshots[childIterator] = _childNodes[childIterator].Save();

            return new SequenceNodeSnapshot(Status, snapshots);
        }

        public void Restore(SequenceNodeSnapshot snapshot)
        {
            Status = snapshot.Status;

            for (int childIterator = 0; childIterator < _childNodes.Length; childIterator += 1)
                _childNodes[childIterator].Restore(snapshot.ChildSnapshots[childIterator]);
        }
    }
}
