namespace BananaParty.BehaviorTree
{
    public abstract class RollbackNode : BehaviorNode, IRollbackNode
    {
        public abstract IRollbackNode Clone();
    }
}
