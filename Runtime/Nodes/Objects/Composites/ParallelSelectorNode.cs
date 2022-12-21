namespace BananaParty.BehaviorTree
{
    public class ParallelSelectorNode : ChainHandlerNode
    {
        protected override bool IsContinuous => false;

        protected override BehaviorNodeType Type => BehaviorNodeType.ParallelSelector;

        public ParallelSelectorNode(IBehaviorNode[] childNodes) : base(childNodes) { }

        protected override IChainNode InstantiateChainNode(IBehaviorNode node)
        {
            return new ParallelChainNode(node, true);
        }
    }
}
