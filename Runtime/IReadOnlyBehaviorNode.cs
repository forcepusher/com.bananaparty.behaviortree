namespace BananaParty.BehaviorTree
{
    /// <remarks>
    /// Entire tree is reevaluated every tick from the root.<br/>
    /// However only relevant nodes are invoked, as they remember their execution state.
    /// </remarks>
    public interface IReadOnlyBehaviorNode
    {
        /// <summary>
        /// Current execution state.
        /// </summary>
        BehaviorNodeStatus Status { get; }

        /// <summary>
        /// Whether the node should be reevaluated when using "Conditional Aborts" or "Reactive Evaluation".<br/>
        /// <see href="https://opsive.com/support/documentation/behavior-designer/conditional-aborts/"/><br/>
        /// <see href="https://nodecanvas.paradoxnotion.com/documentation/?section=reactive-evaluation"/>
        /// </summary>
        bool ReactiveEvaluation { get; }

        /// <summary>
        /// Human-readable node name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Outputs the node and all of its children to a human-readable graph.
        /// </summary>
        void WriteToGraph(ITreeGraph<IReadOnlyBehaviorNode> nodeGraph);
    }
}
