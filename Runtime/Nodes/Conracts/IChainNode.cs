namespace BananaParty.BehaviorTree
{
    public interface IChainNode : IBehaviorNode
    {
        public void AddNextChainLink(IChainNode nextNode);
    }
}
