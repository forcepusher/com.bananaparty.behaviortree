namespace BananaParty.BehaviorTree
{
    public interface ITreeGraphSource
    {
        void WriteTreeToGraph(ITreeGraph<IReadOnlyBehaviorNode> treeGraph);
    }
}
