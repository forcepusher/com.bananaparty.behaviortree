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
        /// Does not require calling base class method when overriding, as it's a callback method.
        /// </remarks>
        public abstract BehaviorNodeStatus OnExecute(long time);

        /// <remarks>
        /// Requires calling base class method when overriding, as it's not a callback method.
        /// </remarks>
        public virtual void Reset()
        {
            Status = BehaviorNodeStatus.Idle;
        }

        /// <remarks>
        /// Requires calling base class getter when overriding, as it's not a callback method
        /// </remarks>
        public virtual string Name
        {
            get
            {
                // I know, GetType() is a dirty shortcut. Give me a break, it's only for debugging.
                string typeName = GetType().Name;
                int postfixStartIndex = typeName.LastIndexOf("Node");
                if (postfixStartIndex == -1)
                    return typeName;

                return typeName.Substring(0, postfixStartIndex);
            }
        }

        /// <remarks>
        /// Requires calling base class method when overriding, as it's not a callback method.
        /// </remarks>
        public virtual void WriteToGraph(ITreeGraph<IReadOnlyBehaviorNode> nodeGraph)
        {
            nodeGraph.Write(this);
        }
    }
}
