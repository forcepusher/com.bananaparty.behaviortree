namespace BananaParty.BehaviorTree
{
    public class Repeat : Decorator
    {
        private readonly NodeStatus? _stopStatus;

        /// <summary>
        /// If <paramref name="stopStatus"/> is specified, the node is guaranteed to end with that exact <see cref="NodeStatus"/>.
        /// </summary>
        public Repeat(INode childNode, NodeStatus? stopStatus = null) : base(childNode)
        {
            _stopStatus = stopStatus;
        }

        public override NodeStatus OnExecute(float deltaTime)
        {
            if (ChildNode.Status > NodeStatus.Running)
                ChildNode.Reset();

            NodeStatus childStatus = ChildNode.Execute(deltaTime);
            if (_stopStatus.HasValue && childStatus == _stopStatus.Value)
                return _stopStatus.Value;

            return NodeStatus.Running;
        }

        public override string Name => $"{base.Name}{(_stopStatus.HasValue ? $"Until{_stopStatus}" : string.Empty)}";
    }
}
