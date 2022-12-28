namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// If Success then Tick Next else Return "same as child".
    /// </summary>
    public class SequenceNode : ChainHandlerNode
    {
        protected override bool IsContinuous => _isContinuous;

        protected override BehaviorNodeType Type => BehaviorNodeType.Sequence;

        private readonly bool _isContinuous;

        public SequenceNode(IBehaviorNode[] childNodes, bool isContinuous = true) : base(childNodes)
        {
            _isContinuous = isContinuous;
        }

        protected override IChainNode InstantiateChainNode(IBehaviorNode node)
        {
            return new SequenceChainNode(node, false);
        }
    }
}
