namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// If Success or Running then Tick Next else Return "same as child".
    /// </summary>
    public class ParallelSequenceNode : ChainHandlerNode
    {
        protected override bool IsContinuous => false;

        protected override BehaviorNodeType Type => BehaviorNodeType.ParallelSequence;

        public ParallelSequenceNode(IBehaviorNode[] childNodes) : base(childNodes) { }

        protected override IChainNode InstantiateChainNode(IBehaviorNode node)
        {
            return new ParallelChainNode(node, false);
        }
    }
}
