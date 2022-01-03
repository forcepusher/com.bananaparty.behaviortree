﻿namespace BehaviorTree.Rollback
{
    public class SequenceRollbackNode : SequenceNode, IRollbackBehaviorNode<SequenceNodeSnapshot>
    {
        private readonly IRollbackBehaviorNode[] _childNodes;

        public SequenceRollbackNode(IRollbackBehaviorNode[] childNodes, bool alwaysReset = false) : base(childNodes, alwaysReset)
        {
            _childNodes = childNodes;
        }

        public SequenceNodeSnapshot Save()
        {
            var snapshots = new ISnapshot[_childNodes.Length];
            for (int childIterator = 0; childIterator < _childNodes.Length; childIterator += 1)
                snapshots[childIterator] = _childNodes[childIterator].Save();

            return new SequenceNodeSnapshot(RunningChildIndex, snapshots);
        }

        public void Restore(SequenceNodeSnapshot snapshot)
        {
            RunningChildIndex = snapshot.RunningChildIndex;

            for (int childIterator = 0; childIterator < _childNodes.Length; childIterator += 1)
                _childNodes[childIterator].Restore(snapshot.ChildSnapshots[childIterator]);
        }
    }
}
