namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// Inverts the result. If the result is Success, then return Failure and vice versa.
    /// </summary>
    public class InverterNode : DecoratorNode
    {
        protected override string Name => "Inverter Node";

        public InverterNode(IBehaviorNode childNode) : base(childNode) { }

        protected override BehaviorNodeStatus OnSuccess()
        {
            return base.OnFailure();
        }

        protected override BehaviorNodeStatus OnFailure()
        {
            return base.OnSuccess();
        }
    }
}
