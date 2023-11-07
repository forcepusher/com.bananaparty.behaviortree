namespace BananaParty.BehaviorTree
{
    public class LockEventNode : BehaviorNode
    {
        private readonly EventNode _eventNode;

        public LockEventNode(EventNode eventNode)
        {
            _eventNode = eventNode;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _eventNode.Lock();
            return BehaviorNodeStatus.Success;
        }
    }
}
