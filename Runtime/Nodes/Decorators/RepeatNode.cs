namespace BananaParty.BehaviorTree
{
    public class RepeatNode : DecoratorNode
    {
        private readonly BehaviorNodeStatus? _stopStatus;

        /// <summary>
        /// If <paramref name="stopStatus"/> is specified, the node is guaranteed to end with that exact <see cref="BehaviorNodeStatus"/>.
        /// </summary>
        public RepeatNode(IBehaviorNode childNode, BehaviorNodeStatus? stopStatus = null) : base(childNode)
        {
            _stopStatus = stopStatus;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (ChildNode.Status > BehaviorNodeStatus.Running)
                ChildNode.Reset();

            BehaviorNodeStatus childStatus = ChildNode.Execute(time);
            if (_stopStatus.HasValue && childStatus == _stopStatus.Value)
                return _stopStatus.Value;

            return BehaviorNodeStatus.Running;
        }

        public override string Name => $"{base.Name}{(_stopStatus.HasValue ? $"Until{_stopStatus}" : string.Empty)}";
    }
}
