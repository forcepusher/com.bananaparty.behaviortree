namespace BananaParty.BehaviorTree
{
    public class LockEvent : Node
    {
        private readonly EventTrigger _eventNode;

        public LockEvent(EventTrigger eventNode)
        {
            _eventNode = eventNode;
        }

        public override NodeStatus OnExecute(float deltaTime)
        {
            _eventNode.Lock();
            return NodeStatus.Success;
        }
    }
}
