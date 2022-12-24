namespace BananaParty.BehaviorTree
{
    public interface INodeDataTextVisualizer
    {
        public string Display(BehaviorNodeVisualizationData node);
        public string DisplayRoot();
    }
}
