namespace BehaviorTree
{
    /// <remarks>
    /// Default interface implementation for IBehaviorNode. Merely a class for code reusal.
    /// </remarks>
    public abstract class BehaviorNode : IBehaviorNode
    {
        public NodeExecutionStatus Status { get; set; }

        public NodeExecutionStatus Execute(long time)
        {
            Status = OnExecute(time);
            return Status;
        }

        public abstract NodeExecutionStatus OnExecute(long time);

        public void Reset()
        {
            Status = NodeExecutionStatus.Idle;
            OnReset();
        }

        public virtual void OnReset() { }

        public virtual void WriteToGraph(INodeGraph nodeGraph)
        {
            nodeGraph.Write(GetType().Name, Status);
        }
    }
}
