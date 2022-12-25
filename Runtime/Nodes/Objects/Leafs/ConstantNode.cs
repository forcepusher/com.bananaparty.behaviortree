namespace BananaParty.BehaviorTree
{
    public class ConstantNode : BehaviorNode
    {
        protected readonly BehaviorNodeStatus _statusToReturn;

        protected override string Name => $"Constant Node {_statusToReturn}";

        /// <summary>
        /// Always returns the specified <paramref name="statusToReturn"/>.
        /// </summary>
        public ConstantNode(BehaviorNodeStatus statusToReturn)
        {
            _statusToReturn = statusToReturn;
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            return (int)_statusToReturn > 0 ? _statusToReturn : BehaviorNodeStatus.Success;
        }
    }
}
