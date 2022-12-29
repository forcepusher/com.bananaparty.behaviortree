namespace BananaParty.BehaviorTree
{
    public abstract class RollbackChainNode : RollbackDecoratorNode, IRollbackChainNode
    {
        protected abstract bool Inverted { get; }

        protected override BehaviorNodeType Type => BehaviorNodeType.Chain;

        private IRollbackChainNode _nextNode;

        public RollbackChainNode(IRollbackNode childNode) : base(childNode) { }

        protected RollbackChainNode(IRollbackNode childNode, IRollbackChainNode nextNode) : base(childNode)
        {
            _nextNode = nextNode;
        }

        public override BehaviorNodeVisualizationData GetVisualizationData()
        {
            var childVisualization = GetChildVisualizationData();
            childVisualization.NextNode = _nextNode?.GetVisualizationData();
            return childVisualization;
        }

        public void AddNextChainLink(IRollbackChainNode nextNode)
        {
            if (_nextNode == null) _nextNode = nextNode;
            else _nextNode.AddNextChainLink(nextNode);
        }

        public abstract IRollbackChainNode Clone();

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

        protected BehaviorNodeStatus PassNext(BehaviorNodeStatus result)
        {
            if (_nextNode != null) return _nextNode.Execute();
            else return result;
        }

        protected IRollbackChainNode CloneNextNode()
        {
            return _nextNode?.Clone();
        }

        protected void RestartNextNode()
        {
            _nextNode?.Restart();
        }
    }
}
