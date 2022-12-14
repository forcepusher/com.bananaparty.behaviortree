namespace YooPita.BT
{
    public interface IChainNode : IBehaviorNode
    {
        public void AddNextChainLink(IChainNode nextNode);
    }
}
