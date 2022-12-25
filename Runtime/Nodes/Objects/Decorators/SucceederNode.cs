namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// If the child node has completed, it always returns Success.
    /// </summary>
    public class SucceederNode : DecoratorNode
    {
        public SucceederNode(IBehaviorNode childNode) : base(childNode) { }

        protected override BehaviorNodeStatus OnFailure()
        {
            return base.OnSuccess();
        }
    }
}
