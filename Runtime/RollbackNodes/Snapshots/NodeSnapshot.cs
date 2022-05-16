namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// Default <see cref="INodeSnapshot"/> implementation for nodes that don't have any state besides <see cref="BehaviorNodeStatus"/>.
    /// </summary>
    public struct NodeSnapshot : INodeSnapshot
    {
        private readonly IRollbackNode _rollbackNode;
        private readonly BehaviorNodeStatus _status;

        public NodeSnapshot(IRollbackNode rollbackNode, BehaviorNodeStatus status)
        {
            _rollbackNode = rollbackNode;
            _status = status;
        }

        public void ApplyState()
        {
            _rollbackNode.Status = _status;
        }
    }
}
