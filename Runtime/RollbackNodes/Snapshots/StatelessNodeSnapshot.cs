namespace BananaParty.BehaviorTree.Rollback
{
    public class StatelessNodeSnapshot : IBehaviorNodeSnapshot
    {
        /// <remarks>
        /// Stateless node still has state, haha. Thanks to <see cref="BehaviorNodeStatus.Idle"/>.
        /// </remarks>
        public BehaviorNodeStatus Status { get; }

        public StatelessNodeSnapshot(BehaviorNodeStatus status)
        {
            Status = status;
        }
    }
}
