using NUnit.Framework;

namespace BananaParty.BehaviorTree.Tests
{
    public class ParallelSequenceNodeTests
    {
        [Test]
        public void ShouldFinishWhenAllChildrenComplete()
        {
            InvocationTestNode[] testNodes = new[]
            {
                new InvocationTestNode(BehaviorNodeStatus.Running),
                new InvocationTestNode(BehaviorNodeStatus.Success),
                new InvocationTestNode(BehaviorNodeStatus.Running)
            };

            var parallelNode = new ParallelSequenceNode(testNodes);
            var nodeStatusResult = parallelNode.Execute();

            Assert.IsTrue(nodeStatusResult == BehaviorNodeStatus.Running, $"Finished too early.");

            testNodes[0].ResultStatus = BehaviorNodeStatus.Success;
            testNodes[2].ResultStatus = BehaviorNodeStatus.Success;
             
            nodeStatusResult = parallelNode.Execute();

            Assert.IsTrue(nodeStatusResult == BehaviorNodeStatus.Success,
                $"Did not finish. {nameof(nodeStatusResult)} = {nodeStatusResult}");
        }

        [Test]
        public void ShouldStopAfterFailure()
        {
            InvocationTestNode[] testNodes = new[]
            {
                new InvocationTestNode(BehaviorNodeStatus.Failure),
                new InvocationTestNode(BehaviorNodeStatus.Success)
            };

            var resultStatus = new ParallelSequenceNode(testNodes).Execute();

            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Failure);
            Assert.IsTrue(testNodes[0].ExecutionCount == 1 && testNodes[1].ExecutionCount == 0);
        }
    }
}
