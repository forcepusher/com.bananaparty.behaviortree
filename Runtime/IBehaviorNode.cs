namespace BehaviorTree
{
    /// <remarks>
    /// Entire tree is reevaluated every tick from the root.
    /// However only relevant nodes are invoked, as they remember their execution state.
    /// </remarks>
    public interface IBehaviorNode
    {
        public NodeExecutionStatus Status { get; }

        public NodeExecutionStatus Execute(long time);

        public void Reset();

        public void WriteToGraph(INodeGraph nodeGraph);
    }
}
