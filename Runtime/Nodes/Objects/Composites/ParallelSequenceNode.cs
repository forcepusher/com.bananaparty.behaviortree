namespace BananaParty.BehaviorTree
{
    public class ParallelSequenceNode : ChainHandlerNode
    {
        protected override bool IsContinuous => false;

        public ParallelSequenceNode(IBehaviorNode[] childNodes) : base(childNodes) { }

        protected override IChainNode InstantiateChainNode(IBehaviorNode node)
        {
            return new ParallelChainNode(node, false);
        }
    }
}
