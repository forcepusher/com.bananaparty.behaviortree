namespace BananaParty.BehaviorTree
{
    public interface IRollbackChainNode : IBehaviorNode
    {
        public void AddNextChainLink(IRollbackChainNode nextNode);
        public IRollbackChainNode Clone();
    }
}
