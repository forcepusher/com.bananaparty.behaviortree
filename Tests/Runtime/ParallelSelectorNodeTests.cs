using NUnit.Framework;
using System.Numerics;

namespace BananaParty.BehaviorTree.Tests
{
    public class ParallelSelectorNodeTests
    {
        [Test]
        public void ShouldFinishWhenAnyChildrenCompletes()
        {
            InvocationTestNode[] testNodes = new[]
            {
                new InvocationTestNode(BehaviorNodeStatus.Failure),
                new InvocationTestNode(BehaviorNodeStatus.Running),
                new InvocationTestNode(BehaviorNodeStatus.Running)
            };

            var parallelNode = new ParallelSelectorNode(testNodes);
            var nodeStatusResult = parallelNode.Execute();

            Assert.IsTrue(nodeStatusResult == BehaviorNodeStatus.Running, $"Finished too early.");

            testNodes[1].ResultStatus = BehaviorNodeStatus.Failure;
            testNodes[2].ResultStatus = BehaviorNodeStatus.Failure;

            nodeStatusResult = parallelNode.Execute();

            Assert.IsTrue(nodeStatusResult == BehaviorNodeStatus.Failure,
                $"Did not finish. {nameof(nodeStatusResult)} = {nodeStatusResult}");
        }

        [Test]
        public void ShouldStopAfterSuccess()
        {
            InvocationTestNode[] testNodes = new[]
            {
                new InvocationTestNode(BehaviorNodeStatus.Success),
                new InvocationTestNode(BehaviorNodeStatus.Failure)
            };

            var resultStatus = new ParallelSelectorNode(testNodes).Execute();

            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Success);
            Assert.IsTrue(testNodes[0].ExecutionCount == 1 && testNodes[1].ExecutionCount == 0);
        }
    }
}
