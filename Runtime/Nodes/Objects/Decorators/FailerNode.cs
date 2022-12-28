namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// If the child node has completed, it always returns Failure.
    /// </summary>
    public class FailerNode : DecoratorNode
    {
        protected override string Name => "Failer Node";

        public FailerNode(IBehaviorNode childNode) : base(childNode) { }

        protected override BehaviorNodeStatus OnSuccess()
        {
            return base.OnFailure();
        }
    }
}
