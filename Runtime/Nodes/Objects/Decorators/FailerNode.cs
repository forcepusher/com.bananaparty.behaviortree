namespace BananaParty.BehaviorTree
{
    public class FailerNode : DecoratorNode
    {
        public FailerNode(IBehaviorNode childNode) : base(childNode) { }

        protected override BehaviorNodeStatus OnSuccess()
        {
            return base.OnFailure();
        }
    }
}
