namespace BananaParty.BehaviorTree
{
    public class UntilResultTree : BehaviorTree
    {
        public UntilResultTree(IBehaviorNode node, INodeVisualizer visualizer = null) : base(node, visualizer) { }

        protected override bool OnSuccess() => true;
        protected override bool OnFailure() => true;
        protected override bool OnRunning() => false;
    }
}
