namespace BananaParty.BehaviorTree
{
    public interface ITreeGraph<TVertex>
    {
        string Name { get; }

        void StartChildGroup(int childCount);

        void Write(TVertex vertex);

        void EndChildGroup();
    }
}
