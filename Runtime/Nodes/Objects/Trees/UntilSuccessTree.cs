namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// Restarts the tree until it completes successfully. Returns true if successful.
    /// </summary>
    public class UntilSuccessTree : BehaviorTree
    {
        public UntilSuccessTree(IBehaviorNode node, IBehaviorTreeVisualizer visualizer = null) : base(node, visualizer) { }

        protected override bool OnSuccess() => true;
        protected override bool OnFailure()
        {
            Reset();
            return false;
        }
        protected override bool OnRunning() => false;
    }
}
