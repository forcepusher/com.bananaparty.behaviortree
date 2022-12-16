namespace BananaParty.BehaviorTree
{
    public interface ITimer
    {
        public void Start();
        public void Reset();
        public bool IsEnded();
    }
}
