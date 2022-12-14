namespace YooPita.BT
{
    public abstract class DecoratorNode : BehaviorNode
    {
        private readonly IBehaviorNode _childNode;

        public DecoratorNode(IBehaviorNode childNode)
        {
            _childNode = childNode;
        }

        protected override void OnRestart()
        {
            _childNode.Restart();
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            return _childNode.Execute();
        }
    }
}
