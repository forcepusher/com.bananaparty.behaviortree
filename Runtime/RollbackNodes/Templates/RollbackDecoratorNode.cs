namespace BananaParty.BehaviorTree
{
    public abstract class RollbackDecoratorNode : BehaviorNode
    {
        private readonly IRollbackNode _childNode;

        protected override BehaviorNodeType Type => BehaviorNodeType.Decorator;

        public RollbackDecoratorNode(IRollbackNode childNode)
        {
            _childNode = childNode;
        }

        public override BehaviorNodeVisualizationData GetVisualizationData()
        {
            return new BehaviorNodeVisualizationData()
            {
                Name = Name,
                State = _state,
                Type = Type,
                ChildNode = _childNode.GetVisualizationData(),
            };
        }

        protected override void OnRestart()
        {
            _childNode.Restart();
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            return _childNode.Execute();
        }

        protected BehaviorNodeVisualizationData GetChildVisualizationData()
        {
            return _childNode.GetVisualizationData();
        }

        protected IRollbackNode CloneChild()
        {
            return _childNode.Clone();
        }
    }
}
