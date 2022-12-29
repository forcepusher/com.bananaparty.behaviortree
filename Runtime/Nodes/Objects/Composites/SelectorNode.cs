namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// If Failure then Tick Next else Return "same as child".
    /// </summary>
    public class SelectorNode : ChainHandlerNode
    {
        protected override string Name => "Selector Node";

        protected override BehaviorNodeType Type => BehaviorNodeType.Selector;

        public SelectorNode(IBehaviorNode[] childNodes, bool isContinuous = true) : base(childNodes, isContinuous)
        {
        }

        protected override IChainNode InstantiateChainNode(IBehaviorNode node)
        {
            return new SequenceChainNode(node, true, IsContinuous);
        }
    }
}
