namespace BananaParty.BehaviorTree
{
    public interface ITreeGraph<TVertex>
    {
        public void StartChildGroup(int childCount);

        public void Write(TVertex vertex);

        public void EndChildGroup();
    }
}
