namespace BananaParty.BehaviorTree
{
    public class SequenceNodeSnapshot : INodeSnapshot
    {
        private readonly SequenceNode _sequenceNode;
        private readonly BehaviorNodeStatus _status;

        public SequenceNodeSnapshot(SequenceNode sequenceNode, BehaviorNodeStatus status)
        {
            _sequenceNode = sequenceNode;
            _status = status;
        }

        public void ApplyState()
        {
            _sequenceNode.Status = _status;
        }
    }
}
