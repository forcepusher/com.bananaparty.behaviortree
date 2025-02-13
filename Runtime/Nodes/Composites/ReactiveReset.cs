namespace BananaParty.BehaviorTree
{
    public class ReactiveReset : Node
    {
        private readonly INode _conditionNode;
        private readonly INode _actionNode;

        private readonly string _descriptionPrefix;

        public ReactiveReset(INode conditionNode, INode actionNode, string descriptionPrefix = "")
        {
            _conditionNode = conditionNode;
            _actionNode = actionNode;
            _descriptionPrefix = descriptionPrefix;
        }

        public override NodeStatus OnExecute(float deltaTime)
        {
            NodeStatus conditionStatus = _conditionNode.Execute(deltaTime);

            if (conditionStatus == NodeStatus.Success)
                _actionNode.Reset();

            NodeStatus actionStatus = _actionNode.Execute(deltaTime);

            return actionStatus;
        }

        public override void OnReset()
        {
            if (_actionNode.Status != NodeStatus.Idle)
                _actionNode.Reset();

            if (_conditionNode.Status != NodeStatus.Idle)
                _conditionNode.Reset();
        }

        public override string Name => $"{_descriptionPrefix}{base.Name}";

        public override void WriteToGraph(ITreeGraph<IReadOnlyNode> nodeGraph)
        {
            base.WriteToGraph(nodeGraph);

            nodeGraph.StartChildGroup(1);
            _conditionNode.WriteToGraph(nodeGraph);
            nodeGraph.EndChildGroup();
            nodeGraph.StartChildGroup(1);
            _actionNode.WriteToGraph(nodeGraph);
            nodeGraph.EndChildGroup();
        }
    }
}
