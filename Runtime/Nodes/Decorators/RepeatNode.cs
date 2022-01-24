namespace BananaParty.BehaviorTree
{
    public class RepeatNode : DecoratorNode
    {
        public RepeatNode(IBehaviorNode childNode) : base(childNode) { }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (ChildNode.Status == BehaviorNodeStatus.Success || ChildNode.Status == BehaviorNodeStatus.Failure)
                ChildNode.Reset();

            ChildNode.Execute(time);

            return BehaviorNodeStatus.Running;
        }
    }
}
