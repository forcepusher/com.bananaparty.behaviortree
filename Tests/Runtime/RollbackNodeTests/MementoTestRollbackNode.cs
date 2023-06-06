namespace BananaParty.BehaviorTree.Tests
{
    public class MementoTestRollbackNode : BehaviorNode, IRollbackNode
    {
        private readonly BehaviorNodeStatus _afterExecutionStatus;

        public MementoTestRollbackNode(BehaviorNodeStatus initialStatus, BehaviorNodeStatus afterExecutionStatus)
        {
            Status = initialStatus;
            _afterExecutionStatus = afterExecutionStatus;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            Status = _afterExecutionStatus;
            return Status;
        }

        public void WriteState(ISnapshotTree snapshotTree)
        {
            snapshotTree.Write(new NodeStatusSnapshot(this, Status));
        }
    }
}
