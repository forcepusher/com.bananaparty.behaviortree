namespace YooPita.BT
{
    public class ParallelSelectorNode : ChainHandlerNode
    {
        protected override bool IsContinuous => false;

        public ParallelSelectorNode(IBehaviorNode[] childNodes) : base(childNodes) { }

        protected override IChainNode InstantiateChainNode(IBehaviorNode node)
        {
            return new ParallelChainNode(node, true);
        }
    }
}
