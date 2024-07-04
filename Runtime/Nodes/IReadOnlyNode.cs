namespace BananaParty.BehaviorTree
{
    public interface IReadOnlyNode
    {
        /// <summary>
        /// Current execution state.
        /// </summary>
        NodeStatus Status { get; }

        /// <summary>
        /// Human-readable node name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Outputs the node and all of its children to a human-readable graph.
        /// </summary>
        void WriteToGraph(ITreeGraph<IReadOnlyNode> graph);
    }
}
