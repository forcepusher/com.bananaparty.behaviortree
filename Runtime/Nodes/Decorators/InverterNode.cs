namespace BananaParty.BehaviorTree
{
    public class InverterNode : DecoratorNode
    {
        public InverterNode(IBehaviorNode childNode) : base(childNode) { }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            BehaviorNodeStatus childStatus = ChildNode.Execute(time);

            return childStatus switch
            {
                BehaviorNodeStatus.Success => BehaviorNodeStatus.Failure,
                BehaviorNodeStatus.Failure => BehaviorNodeStatus.Success,
                _ => childStatus,
            };
        }
    }
}
