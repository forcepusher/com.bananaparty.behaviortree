namespace BananaParty.BehaviorTree
{
    /// <remarks>
    /// Default interface implementation for IBehaviorNode. Merely a class for code reusal.<br/>
    /// Won't be that big of a deal to get rid of it and use the interfaces alone.
    /// </remarks>
    public abstract class BehaviorNode : IBehaviorNode
    {
        public BehaviorNodeStatus Status { get; set; }

        public BehaviorNodeStatus Execute(long time)
        {
            Status = OnExecute(time);
            return Status;
        }

        /// <remarks>
        /// Does not require calling base class method when overriding. It's a callback method.
        /// </remarks>
        public abstract BehaviorNodeStatus OnExecute(long time);

        public void Reset()
        {
            OnReset();
            Status = BehaviorNodeStatus.Idle;
        }

        /// <remarks>
        /// Does not require calling base class method when overriding. It's a callback method.
        /// If the current <see cref="Status"/> was <see cref="BehaviorNodeStatus.Running"/>, then it's an interruption.<br/>
        /// </remarks>
        public virtual void OnReset() { }

        public virtual string Name
        {
            get
            {
                string typeName = GetType().Name;
                int postfixStartIndex = typeName.LastIndexOf("Node");
                if (postfixStartIndex == -1)
                    return typeName;

                return typeName.Substring(0, postfixStartIndex);
            }
        }

        public virtual void WriteToGraph(ITreeGraph<IReadOnlyBehaviorNode> nodeGraph)
        {
            nodeGraph.Write(this);
        }
    }
}
