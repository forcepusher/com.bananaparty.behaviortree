using NUnit.Framework;
using System.Linq;

namespace BananaParty.BehaviorTree.Tests
{
    public class SequenceNodeTests
    {
        [Test]
        public void ShouldExecuteAllChildrenOnce()
        {
            InvocationTestNode[] testNodes = new[]
            {
                new InvocationTestNode(BehaviorNodeStatus.Success),
                new InvocationTestNode(BehaviorNodeStatus.Success),
                new InvocationTestNode(BehaviorNodeStatus.Success)
            };

            var resultStatus = new SequenceNode(testNodes).Execute();

            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Success);
            Assert.IsTrue(testNodes.All(testNode => testNode.ExecutionCount == 1));
        }

        [Test]
        public void ShouldStopAfterFailure()
        {
            InvocationTestNode[] testNodes = new[]
            {
                new InvocationTestNode(BehaviorNodeStatus.Failure),
                new InvocationTestNode(BehaviorNodeStatus.Success)
            };

            var resultStatus = new SequenceNode(testNodes).Execute();

            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Failure);
            Assert.IsTrue(testNodes[0].ExecutionCount == 1 && testNodes[1].ExecutionCount == 0);
        }

        [Test]
        public void ShouldStopAfterRunning()
        {
            InvocationTestNode[] testNodes = new[]
            {
                new InvocationTestNode(BehaviorNodeStatus.Running),
                new InvocationTestNode(BehaviorNodeStatus.Success)
            };

            var resultStatus = new SequenceNode(testNodes).Execute();

            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Running);
            Assert.IsTrue(testNodes[0].ExecutionCount == 1 && testNodes[1].ExecutionCount == 0);
        }
    }
}
