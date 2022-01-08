namespace BananaParty.BehaviorTree
{
    public class RepeatNode : DecoratorNode
    {
        public RepeatNode(IBehaviorNode childNode) : base(childNode) { }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            ChildNode.Execute(time);

            return BehaviorNodeStatus.Running;
        }
    }
}
