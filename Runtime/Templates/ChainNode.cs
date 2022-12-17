namespace BananaParty.BehaviorTree
{
    public abstract class ChainNode : BehaviorNode, IChainNode
    {
        protected abstract bool Inverted { get; }

        protected abstract IBehaviorNode HandledNode { get; }

        protected override BehaviorNodeType Type => BehaviorNodeType.Chain;

        private IChainNode NextLink;

        public override BehaviorNodeVisualizationData GetVisualizationData()
        {
            return new BehaviorNodeVisualizationData()
            {
                Name = Name,
                State = _state,
                Type = Type,
                ChildNode = HandledNode.GetVisualizationData(),
                NextNode = NextLink.GetVisualizationData(),
            };
        }

        public void AddNextChainLink(IChainNode nextNode)
        {
            if (NextLink == null) NextLink = nextNode;
            else NextLink.AddNextChainLink(nextNode);
        }

        protected override BehaviorNodeStatus OnSuccess()
        {
            if (!Inverted) return PassNext();
            else return BehaviorNodeStatus.Failure;
        }

        protected override BehaviorNodeStatus OnFailure()
        {
            if (Inverted) return PassNext();
            else return BehaviorNodeStatus.Failure;
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            return HandledNode.Execute();
        }

        protected override void OnRestart()
        {
            HandledNode.Restart();
            NextLink?.Restart();
        }

        protected BehaviorNodeStatus PassNext()
        {
            if (NextLink != null) return NextLink.Execute();
            else return BehaviorNodeStatus.Success;
        }
    }
}
