namespace BananaParty.BehaviorTree.Rollback
{
    public interface IRollbackBehaviorNode<TSnapshot> : IBehaviorNode where TSnapshot : IBehaviorNodeSnapshot
    {
        public TSnapshot Save();

        public void Restore(TSnapshot snapshot);
    }

    // Makes things look like magic, we don't want that. Reduces the type length though.
    //public interface IRollbackBehaviorNode : IRollbackBehaviorNode<IBehaviorNodeSnapshot> { }
}
