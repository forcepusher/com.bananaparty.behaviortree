namespace BananaParty.BehaviorTree
{
    public interface IRollbackNode : IBehaviorNode
    {
        /// <summary>
        /// Create copy of this node for rollback.
        /// </summary>
        IRollbackNode Copy();
    }
}
