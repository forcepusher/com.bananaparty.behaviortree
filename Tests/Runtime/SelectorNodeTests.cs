using NUnit.Framework;
using System.Linq;

namespace BananaParty.BehaviorTree.Tests
{
    public class SelectorNodeTests
    {
        [Test]
        public void ShouldExecuteAllChildrenOnce()
        {
            InvocationTestNode[] testNodes = new[]
            {
                new InvocationTestNode(BehaviorNodeStatus.Failure),
                new InvocationTestNode(BehaviorNodeStatus.Failure),
                new InvocationTestNode(BehaviorNodeStatus.Failure)
            };

            var resultStatus = new SelectorNode(testNodes).Execute();

            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Failure);
            Assert.IsTrue(testNodes.All(testNode => testNode.ExecutionCount == 1));
        }

        [Test]
        public void ShouldStopAfterSuccess()
        {
            InvocationTestNode[] testNodes = new[]
            {
                new InvocationTestNode(BehaviorNodeStatus.Success),
                new InvocationTestNode(BehaviorNodeStatus.Failure)
            };

            var resultStatus = new SelectorNode(testNodes).Execute();

            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Success);
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

            var resultStatus = new SelectorNode(testNodes).Execute();

            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Running);
            Assert.IsTrue(testNodes[0].ExecutionCount == 1 && testNodes[1].ExecutionCount == 0);
        }

        [Test]
        public void MustRespondToInterrupt()
        {
            InvocationTestNode[] testNodes = new[]
            {
                new InvocationTestNode(BehaviorNodeStatus.Failure),
                new InvocationTestNode(BehaviorNodeStatus.Running)
            };

            var node = new SelectorNode(testNodes, false);
            var resultStatus = node.Execute();

            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Running);
            Assert.IsTrue(testNodes[0].ExecutionCount == 1 && testNodes[1].ExecutionCount == 1);

            testNodes[0].ResultStatus = BehaviorNodeStatus.Success;
            resultStatus = node.Execute();

            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Success);
            Assert.IsTrue(testNodes[0].ExecutionCount == 2 && testNodes[1].ExecutionCount == 1);
        }

        [Test]
        public void MustNotRespondToInterrupt()
        {
            InvocationTestNode[] testNodes = new[]
            {
                new InvocationTestNode(BehaviorNodeStatus.Failure),
                new InvocationTestNode(BehaviorNodeStatus.Running)
            };

            var node = new SelectorNode(testNodes, true);
            var resultStatus = node.Execute();

            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Running);
            Assert.IsTrue(testNodes[0].ExecutionCount == 1 && testNodes[1].ExecutionCount == 1);

            testNodes[0].ResultStatus = BehaviorNodeStatus.Success;
            resultStatus = node.Execute();

            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Running);
            Assert.IsTrue(testNodes[0].ExecutionCount == 1 && testNodes[1].ExecutionCount == 2);
        }
    }
}
