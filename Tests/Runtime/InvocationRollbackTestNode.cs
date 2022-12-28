namespace BananaParty.BehaviorTree.Tests
{
    public class InvocationRollbackTestNode : RollbackNode
    {
        protected override string Name => "Invocation Rollback Test Node";

        public int ExecutionCount { get; private set; } = 0;
        public BehaviorNodeStatus ResultStatus { get; set; } = BehaviorNodeStatus.Idle;

        public InvocationRollbackTestNode(BehaviorNodeStatus statusToReturn)
        {
            ResultStatus = statusToReturn;
        }

        private InvocationRollbackTestNode(BehaviorNodeStatus statusToReturn, int executionCount)
        {
            ResultStatus = statusToReturn;
            ExecutionCount = executionCount;
        }

        public override IRollbackNode Clone()
        {
            return new InvocationRollbackTestNode(ResultStatus, ExecutionCount);
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            ExecutionCount += 1;
            return ResultStatus;
        }
    }
}
