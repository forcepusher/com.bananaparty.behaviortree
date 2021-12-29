namespace BehaviorTree
{
    /// <remarks>
    /// Entire tree is reevaluated every tick from the root.
    /// However only relevant nodes are invoked, as composites remember their execution state.
    /// </remarks>
    public interface IBehaviorNode
    {
        public NodeExecutionStatus Execute(long time);

        /// <summary>
        /// Return <see cref="NodeExecutionStatus.Failure"/> or <see cref="NodeExecutionStatus.Success"/> to successfully interrupt the task.<br/>
        /// Otherwise, return <see cref="NodeExecutionStatus.Running"/> to ignore the request and continue execution.
        /// </summary>
        public NodeExecutionStatus Interrupt(long time);

        public void WriteToGraph(INodeGraph nodeGraph);
    }
}
