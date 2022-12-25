namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// Returns true if the tree has ended.
    /// </summary>
    public class UntilResultTree : BehaviorTree
    {
        public UntilResultTree(IBehaviorNode node, IBehaviorTreeVisualizer visualizer = null) : base(node, visualizer) { }

        protected override bool OnSuccess() => true;
        protected override bool OnFailure() => true;
        protected override bool OnRunning() => false;
    }
}
