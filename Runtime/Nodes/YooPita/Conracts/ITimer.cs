namespace YooPita.BT
{
    public interface ITimer
    {
        public void Start();
        public void Reset();
        public bool IsEnded();
    }
}
