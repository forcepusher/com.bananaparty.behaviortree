namespace BananaParty.BehaviorTree
{
    public class Override : Decorator
    {
        private readonly NodeStatus _returnStatus;

        public Override(INode childNode, NodeStatus returnStatus) : base(childNode)
        {
            _returnStatus = returnStatus;
        }

        public override NodeStatus OnExecute(float deltaTime)
        {
            NodeStatus childStatus = ChildNode.Execute(deltaTime);

            if (childStatus > NodeStatus.Running)
                return _returnStatus;

            return childStatus;
        }
    }
}
