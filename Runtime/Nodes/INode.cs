namespace BananaParty.BehaviorTree
{
    public interface INode : IReadOnlyNode
    {
        NodeStatus Execute(float deltaTime);

        /// <summary>
        /// Interrupts execution and resets state of the node and its children.<br/>
        /// Used for both resetting and interrupting node execution.
        /// </summary>
        void Reset();
    }
}
