namespace BananaParty.BehaviorTree
{
    public class UnlockEventNode : BehaviorNode
    {
        private readonly EventNode _eventNode;

        public UnlockEventNode(EventNode eventNode)
        {
            _eventNode = eventNode;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _eventNode.Unlock();
            return BehaviorNodeStatus.Success;
        }
    }
}
