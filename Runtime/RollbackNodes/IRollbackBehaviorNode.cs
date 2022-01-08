namespace BehaviorTree.Rollback
{
    public interface IRollbackBehaviorNode<TSnapshot> : IBehaviorNode where TSnapshot : IBehaviorNodeSnapshot
    {
        public TSnapshot Save();

        public void Restore(TSnapshot snapshot);
    }

    public interface IRollbackBehaviorNode : IRollbackBehaviorNode<IBehaviorNodeSnapshot> { }
}
