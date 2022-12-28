using NUnit.Framework;

namespace BananaParty.BehaviorTree.Tests
{
    public class ParallelFirstCompleteNodeTests
    {
        [Test]
        public void ShouldReturnFirstSuccess()
        {
            InvocationTestNode[] testNodes = new[]
            {
                new InvocationTestNode(BehaviorNodeStatus.Running),
                new InvocationTestNode(BehaviorNodeStatus.Success),
                new InvocationTestNode(BehaviorNodeStatus.Failure)
            };

            var resultStatus = new ParallelFirstCompleteNode(testNodes).Execute();

            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Success);
            Assert.IsTrue(testNodes[0].ExecutionCount == 1
                && testNodes[1].ExecutionCount == 1
                && testNodes[2].ExecutionCount == 0);
        }

        [Test]
        public void ShouldReturnFirstFailure()
        {
            InvocationTestNode[] testNodes = new[]
            {
                new InvocationTestNode(BehaviorNodeStatus.Running),
                new InvocationTestNode(BehaviorNodeStatus.Failure),
                new InvocationTestNode(BehaviorNodeStatus.Success)
            };

            var resultStatus = new ParallelFirstCompleteNode(testNodes).Execute();

            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Failure);
            Assert.IsTrue(testNodes[0].ExecutionCount == 1
                && testNodes[1].ExecutionCount == 1
                && testNodes[2].ExecutionCount == 0);
        }

        [Test]
        public void ShouldReturnRunning()
        {
            InvocationTestNode[] testNodes = new[]
            {
                new InvocationTestNode(BehaviorNodeStatus.Running),
                new InvocationTestNode(BehaviorNodeStatus.Running)
            };

            var resultStatus = new ParallelFirstCompleteNode(testNodes).Execute();

            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Running);
            Assert.IsTrue(testNodes[0].ExecutionCount == 1
                && testNodes[1].ExecutionCount == 1);
        }
    }
}
