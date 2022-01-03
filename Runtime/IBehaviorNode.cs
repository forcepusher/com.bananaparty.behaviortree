namespace BehaviorTree
{
    /// <remarks>
    /// Entire tree is reevaluated every tick from the root.
    /// However only relevant nodes are invoked, as composites remember their execution state.
    /// </remarks>
    public interface IBehaviorNode
    {
        public NodeExecutionStatus Execute(long time);

        public void WriteToGraph(INodeGraph nodeGraph)
        {
            nodeGraph.Write(GetType().Name);
        }
    }
}
