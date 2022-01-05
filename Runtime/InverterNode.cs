namespace BehaviorTree
{
    public class InverterNode : BehaviorNode
    {
        private readonly IBehaviorNode _childNode;

        protected NodeExecutionStatus ChildStatus;

        public InverterNode(IBehaviorNode childNode)
        {
            _childNode = childNode;
        }

        public override NodeExecutionStatus OnExecute(long time)
        {
            ChildStatus = _childNode.Execute(time);

            return ChildStatus switch
            {
                NodeExecutionStatus.Success => NodeExecutionStatus.Failure,
                NodeExecutionStatus.Failure => NodeExecutionStatus.Success,
                _ => ChildStatus,
            };
        }

        public override void OnReset()
        {
            _childNode.Reset();
        }

        public override void WriteToGraph(INodeGraph nodeGraph)
        {
            base.WriteToGraph(nodeGraph);

            nodeGraph.StartChildGroup(1);
            _childNode.WriteToGraph(nodeGraph);
            nodeGraph.EndChildGroup();
        }
    }
}
