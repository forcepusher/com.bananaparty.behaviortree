namespace BehaviorTree.Rollback
{
    public interface IRollbackBehaviorNode<TSnapshot> : IBehaviorNode where TSnapshot : ISnapshot
    {
        public TSnapshot Save();

        public void Restore(TSnapshot snapshot);
    }

    public interface IRollbackBehaviorNode : IRollbackBehaviorNode<ISnapshot> { }
}
