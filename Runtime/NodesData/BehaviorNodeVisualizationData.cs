namespace BananaParty.BehaviorTree
{
    public class BehaviorNodeVisualizationData
    {
        public string Name { get; set; }
        public BehaviorNodeType Type { get; set; }
        public BehaviorNodeStatus State { get; set; }
        public BehaviorNodeVisualizationData ChildNode { get; set; }
        public BehaviorNodeVisualizationData NextNode { get; set; }
    }
}
