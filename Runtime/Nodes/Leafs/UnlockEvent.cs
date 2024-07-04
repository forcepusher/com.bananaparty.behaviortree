namespace BananaParty.BehaviorTree
{
    public class UnlockEvent : Node
    {
        private readonly EventTrigger _eventNode;

        public UnlockEvent(EventTrigger eventNode)
        {
            _eventNode = eventNode;
        }

        public override NodeStatus OnExecute(float deltaTime)
        {
            _eventNode.Unlock();
            return NodeStatus.Success;
        }
    }
}
