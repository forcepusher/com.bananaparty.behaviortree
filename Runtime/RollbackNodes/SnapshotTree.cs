using System.Collections.Generic;

namespace BananaParty.BehaviorTree
{
    public class SnapshotTree : ISnapshotTree
    {
        // I lied, it's not actually a tree.
        private readonly List<INodeSnapshot> _nodeSnapshots = new();

        public void Write(INodeSnapshot nodeSnapshot)
        {
            _nodeSnapshots.Add(nodeSnapshot);
        }

        public void ApplyState()
        {
            foreach (INodeSnapshot nodeSnapshot in _nodeSnapshots)
                nodeSnapshot.ApplyState();
        }
    }
}
