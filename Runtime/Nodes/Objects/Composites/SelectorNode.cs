namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// If Failure then Tick Next else Return "same as child".
    /// </summary>
    public class SelectorNode : ChainHandlerNode
    {
        protected override bool IsContinuous => _isContinuous;

        protected override BehaviorNodeType Type => BehaviorNodeType.Selector;

        private readonly bool _isContinuous;

        public SelectorNode(IBehaviorNode[] childNodes, bool isContinuous = true) : base(childNodes)
        {
            _isContinuous = isContinuous;
        }

        protected override IChainNode InstantiateChainNode(IBehaviorNode node)
        {
            return new SequenceChainNode(node, true);
        }
    }
}
