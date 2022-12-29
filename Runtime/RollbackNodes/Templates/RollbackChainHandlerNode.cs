namespace BananaParty.BehaviorTree
{
    public abstract class RollbackChainHandlerNode : BehaviorNode, IRollbackNode
    {
        protected bool IsContinuous { private set; get; }

        protected IRollbackChainNode _chain;

        public RollbackChainHandlerNode(IRollbackNode[] childNodes, bool isContinuous = true)
        {
            IsContinuous = isContinuous;
            _chain = InstantiateChainNode(childNodes[0]);
            AddNodesToChain(childNodes);
        }

        protected RollbackChainHandlerNode() { }

        public override BehaviorNodeVisualizationData GetVisualizationData()
        {
            return new BehaviorNodeVisualizationData()
            {
                Name = Name,
                State = _state,
                Type = Type,
                ChildNode = _chain.GetVisualizationData(),
            };
        }

        public abstract IRollbackNode Clone();

        protected abstract IRollbackChainNode InstantiateChainNode(IRollbackNode node);

        protected override BehaviorNodeStatus OnExecute()
        {
            return _chain.Execute();
        }

        protected override void OnRestart()
        {
            _chain.Restart();
        }

        private void AddNodesToChain(IRollbackNode[] childNodes)
        {
            for (int i = 1; i < childNodes.Length; i++)
            {
                _chain.AddNextChainLink(InstantiateChainNode(childNodes[i]));
            }
        }
    }
}
