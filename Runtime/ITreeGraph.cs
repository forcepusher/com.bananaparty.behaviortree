namespace BananaParty.BehaviorTree
{
    public interface ITreeGraph<TVertex>
    {
        void StartChildGroup(int childCount);

        void Write(TVertex vertex);

        void EndChildGroup();
    }
}
