namespace BehaviorTree.Rollback
{
    public interface IRollbackBehaviorNode<TSnapshot> : IBehaviorNode where TSnapshot : ISnapshot
    {
        public void Restore(TSnapshot snapshot);

        public TSnapshot Save();
    }

    public interface IRollbackBehaviorNode : IRollbackBehaviorNode<ISnapshot> { }
}
