namespace BananaParty.BehaviorTree
{
    public abstract class ChainHandlerNode : BehaviorNode
    {
        protected abstract bool IsContinuous { get; }

        private readonly IChainNode _chain;

        public ChainHandlerNode(IBehaviorNode[] childNodes)
        {
            _chain = InstantiateChainNode(childNodes[0]);
            AddNodesToChain(childNodes);
        }

        protected abstract IChainNode InstantiateChainNode(IBehaviorNode node);

        protected override BehaviorNodeStatus OnExecute()
        {
            if (!IsContinuous) _chain.Restart();
            return _chain.Execute();
        }

        protected override void OnRestart()
        {
            _chain.Restart();
        }

        private void AddNodesToChain(IBehaviorNode[] childNodes)
        {
            for (int i = 1; i < childNodes.Length; i++)
            {
                _chain.AddNextChainLink(InstantiateChainNode(childNodes[i]));
            }
        }
    }
}
