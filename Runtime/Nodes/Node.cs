namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// Default <see cref="INode"/> implementation with <see cref="OnExecute(float)"/> and <see cref="OnReset"/> callbacks for convenience
    /// </summary>
    public abstract class Node : INode
    {
        public NodeStatus Status { get; set; }

        public NodeStatus Execute(float deltaTime)
        {
            Status = OnExecute(deltaTime);
            return Status;
        }

        /// <remarks>
        /// Does not require calling base class method when overriding. It's a callback method.
        /// </remarks>
        public abstract NodeStatus OnExecute(float deltaTime);

        public void Reset()
        {
            OnReset();
            Status = NodeStatus.Idle;
        }

        /// <remarks>
        /// Does not require calling base class method when overriding. It's a callback method.
        /// If the current <see cref="Status"/> was <see cref="NodeStatus.Running"/>, then it's an interruption.<br/>
        /// </remarks>
        public virtual void OnReset() { }

        public virtual string Name => GetType().Name;

        public virtual void WriteToGraph(ITreeGraph<IReadOnlyNode> nodeGraph) => nodeGraph.Write(this);
    }
}
