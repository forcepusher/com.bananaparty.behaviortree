namespace BananaParty.BehaviorTree
{
    public abstract class ChainNode : DecoratorNode, IChainNode
    {
        protected abstract bool Inverted { get; }

        protected override BehaviorNodeType Type => BehaviorNodeType.Chain;

        private IChainNode _nextNode;

        public ChainNode(IBehaviorNode childNode) : base(childNode) { }

        public override BehaviorNodeVisualizationData GetVisualizationData()
        {
            var childVisualization = GetChildVisualizationData();
            childVisualization.NextNode = _nextNode?.GetVisualizationData();
            return childVisualization;
        }

        public void AddNextChainLink(IChainNode nextNode)
        {
            if (_nextNode == null) _nextNode = nextNode;
            else _nextNode.AddNextChainLink(nextNode);
        }

        protected override BehaviorNodeStatus OnSuccess()
        {
            if (!Inverted) return PassNext(BehaviorNodeStatus.Success);
            else return BehaviorNodeStatus.Success;
        }

        protected override BehaviorNodeStatus OnFailure()
        {
            if (Inverted) return PassNext(BehaviorNodeStatus.Failure);
            else return BehaviorNodeStatus.Failure;
        }

        protected override void OnRestart()
        {
            base.OnRestart();
            RestartNextNode();
        }

        protected void RestartNextNode()
        {
            _nextNode?.Restart();
        }

        protected BehaviorNodeStatus PassNext(BehaviorNodeStatus result)
        {
            if (_nextNode != null) return _nextNode.Execute();
            else return result;
        }
    }
}
