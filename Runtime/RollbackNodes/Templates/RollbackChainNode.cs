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
            return new BehaviorNodeVisualizationData()
            {
                Name = Name,
                State = _state,
                Type = Type,
                ChildNode = GetChildVisualizationData(),
                NextNode = _nextNode.GetVisualizationData(),
            };
        }

        public void AddNextChainLink(IRollbackChainNode nextNode)
        {
            if (_nextNode == null) _nextNode = nextNode;
            else _nextNode.AddNextChainLink(nextNode);
        }

        public abstract IRollbackChainNode Clone();

        protected override BehaviorNodeStatus OnSuccess()
        {
            if (!Inverted) return PassNext();
            else return BehaviorNodeStatus.Failure;
        }

        protected override BehaviorNodeStatus OnFailure()
        {
            if (Inverted) return PassNext();
            else return BehaviorNodeStatus.Failure;
        }

        protected override void OnRestart()
        {
            base.OnRestart();
            _nextNode?.Restart();
        }

        protected BehaviorNodeStatus PassNext()
        {
            if (_nextNode != null) return _nextNode.Execute();
            else return BehaviorNodeStatus.Success;
        }

        protected IRollbackChainNode CloneNextNode()
        {
            return _nextNode.Clone();
        }
    }
}
