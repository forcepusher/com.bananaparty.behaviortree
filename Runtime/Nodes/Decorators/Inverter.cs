namespace BananaParty.BehaviorTree
{
    public class Inverter : Decorator
    {
        public Inverter(INode childNode) : base(childNode) { }

        public override NodeStatus OnExecute(float deltaTime)
        {
            NodeStatus childStatus = ChildNode.Execute(deltaTime);

            return childStatus switch
            {
                NodeStatus.Success => NodeStatus.Failure,
                NodeStatus.Failure => NodeStatus.Success,
                _ => childStatus,
            };
        }
    }
}
