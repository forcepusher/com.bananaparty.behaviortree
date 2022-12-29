namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// If Failure or Running then Tick Next else Return "same as child".
    /// </summary>
    public class ParallelSelectorNode : ChainHandlerNode
    {
        protected override string Name => "Parallel Selector Node";

        protected override BehaviorNodeType Type => BehaviorNodeType.ParallelSelector;

        public ParallelSelectorNode(IBehaviorNode[] childNodes) : base(childNodes) { }

        protected override IChainNode InstantiateChainNode(IBehaviorNode node)
        {
            return new ParallelChainNode(node, true);
        }
    }
}
