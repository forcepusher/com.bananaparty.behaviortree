namespace BananaParty.BehaviorTree
{
    public class SequenceChainNode : ChainNode
    {
        protected override bool Inverted => _inverted;

        private readonly bool _inverted;

        public SequenceChainNode(IBehaviorNode childNode, bool inverted) : base(childNode)
        {
            _inverted = inverted;
        }
    }
}
