namespace BananaParty.BehaviorTree
{
    public interface IBehaviorNode : IReadOnlyBehaviorNode
    {
        /// <summary>
        /// Evaluate the node and its children relevant to current execution state.
        /// </summary>
        /// <param name="time">Frame/tick number or execution time (preferably milliseconds).</param>
        /// <remarks>
        /// Entire tree is reevaluated every tick from the root.<br/>
        /// However only relevant nodes are invoked, as they remember their execution state.<br/>
        /// Sets <see cref="IReadOnlyBehaviorNode.Status"/> to the value returned by this method.
        /// </remarks>
        BehaviorNodeStatus Execute(long time);

        /// <summary>
        /// Interrupts execution and resets state of the node and its children.<br/>
        /// Used for both resetting and interrupting node execution.<br/>
        /// <see cref="IReadOnlyBehaviorNode.Status"/> is set back to <see cref="BehaviorNodeStatus.Idle"/>.
        /// </summary>
        void Reset();
    }
}
