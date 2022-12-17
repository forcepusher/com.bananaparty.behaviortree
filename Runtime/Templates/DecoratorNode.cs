namespace BananaParty.BehaviorTree
{
    public abstract class DecoratorNode : BehaviorNode
    {
        private readonly IBehaviorNode _childNode;

        protected override BehaviorNodeType Type => BehaviorNodeType.Decorator;

        public DecoratorNode(IBehaviorNode childNode)
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
    }
}
