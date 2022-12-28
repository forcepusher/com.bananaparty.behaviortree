namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// A link in a chain that provides consistent chain logic.
    /// </summary>
    public class SequenceChainNode : ChainNode
    {
        protected override string Name => "Sequence Chain Node";

        protected override bool Inverted => _inverted;

        private readonly bool _inverted;

        public SequenceChainNode(IBehaviorNode childNode, bool inverted) : base(childNode)
        {
            _inverted = inverted;
        }
    }
}
