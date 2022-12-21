namespace BananaParty.BehaviorTree
{
    public interface ITimer
    {
        public void StartIfNot();
        public void Reset();
        public bool IsEnded();
    }
}
