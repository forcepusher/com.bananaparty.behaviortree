namespace BananaParty.BehaviorTree
{
    public class UntilSuccessTree : BehaviorTree
    {
        public UntilSuccessTree(IBehaviorNode node, IBehaviorTreeVisualizer visualizer = null) : base(node, visualizer) { }

        protected override bool OnSuccess() => true;
        protected override bool OnFailure() => false;
        protected override bool OnRunning() => false;
    }
}
