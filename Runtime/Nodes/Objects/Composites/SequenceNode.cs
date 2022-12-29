namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// If Success then Tick Next else Return "same as child".
    /// </summary>
    public class SequenceNode : ChainHandlerNode
    {
        protected override string Name => "Sequence Node";

        protected override BehaviorNodeType Type => BehaviorNodeType.Sequence;


        public SequenceNode(IBehaviorNode[] childNodes, bool isContinuous = true) : base(childNodes, isContinuous)
        {
        }

        protected override IChainNode InstantiateChainNode(IBehaviorNode node)
        {
            return new SequenceChainNode(node, false, IsContinuous);
        }
    }
}
