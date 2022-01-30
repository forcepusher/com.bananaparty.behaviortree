namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// Default <see cref="INodeSnapshot"/> implementation for nodes that don't have any state besides <see cref="BehaviorNodeStatus"/>.
    /// </summary>
    public class NodeSnapshot : INodeSnapshot
    {
        private readonly IBehaviorNode _behaviorNode;
        private readonly BehaviorNodeStatus _status;

        public NodeSnapshot(IBehaviorNode behaviorNode, BehaviorNodeStatus status)
        {
            _behaviorNode = behaviorNode;
            _status = status;
        }

        public void ApplyState()
        {
            _behaviorNode.Status = _status;
        }
    }
}
