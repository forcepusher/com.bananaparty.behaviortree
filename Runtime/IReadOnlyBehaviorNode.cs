namespace BananaParty.BehaviorTree
{
    /// <remarks>
    /// Entire tree is reevaluated every tick from the root.<br/>
    /// However only relevant nodes are invoked, as they remember their execution state.
    /// </remarks>
    public interface IReadOnlyBehaviorNode
    {
        /// <summary>
        /// Human-readable node name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Current execution state.
        /// </summary>
        public BehaviorNodeStatus Status { get; }

        /// <summary>
        /// Outputs the node and all of its children to a human-readable graph.
        /// </summary>
        public void WriteToGraph(ITreeGraph<IReadOnlyBehaviorNode> nodeGraph);
    }
}
