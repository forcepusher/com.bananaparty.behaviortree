using System;

namespace BananaParty.BehaviorTree
{
    public abstract class RollbackChainHandlerNode : BehaviorNode, IRollbackNode
    {
        protected abstract bool IsContinuous { get; }

        protected IRollbackChainNode _chain;

        protected IRollbackChainNode _snapshot;

        public RollbackChainHandlerNode(IRollbackChainNode[] childNodes)
        {
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

        public void Restore()
        {
            if (_snapshot == null)
                throw new NullReferenceException("Object is null");
            Restart();
            _chain = _snapshot;
        }

        protected abstract IRollbackChainNode InstantiateChainNode(IRollbackChainNode node);

        protected override BehaviorNodeStatus OnExecute()
        {
            if (!IsContinuous) _chain.Restart();
            return _chain.Execute();
        }

        protected override void OnRestart()
        {
            _chain.Restart();
        }

        private void AddNodesToChain(IRollbackChainNode[] childNodes)
        {
            for (int i = 1; i < childNodes.Length; i++)
            {
                _chain.AddNextChainLink(InstantiateChainNode(childNodes[i]));
            }
        }
    }
}
