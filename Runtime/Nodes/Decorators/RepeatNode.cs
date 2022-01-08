namespace BehaviorTree
{
    public class RepeatNode : DecoratorNode
    {
        public RepeatNode(IBehaviorNode childNode) : base(childNode) { }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            BehaviorNodeStatus childStatus = ChildNode.Execute(time);
            if (childStatus != BehaviorNodeStatus.Success)
                childStatus = BehaviorNodeStatus.Running;

            return childStatus;
        }
    }
}
