namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// Sequentially runs multiple nodes in parallel and returns as soon as first child completes.
    /// </summary>
    public class ParallelFirstCompleteNode : ChainHandlerNode
    {
        protected override string Name => "Parallel First Complete Node";

        protected override BehaviorNodeType Type => BehaviorNodeType.ParallelFirstComplete;

        public ParallelFirstCompleteNode(IBehaviorNode[] childNodes) : base(childNodes) { }

        protected override IChainNode InstantiateChainNode(IBehaviorNode node)
        {
            return new ParallelFirstCompleteChainNode(node);
        }
    }
}
