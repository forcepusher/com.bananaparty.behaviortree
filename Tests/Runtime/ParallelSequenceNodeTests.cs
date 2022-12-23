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

            Assert.IsFalse(StatusIsFinished(nodeStatusResult), $"Finished too early.");

            testNodes[0].Status = BehaviorNodeStatus.Success;
            testNodes[2].Status = BehaviorNodeStatus.Success;

            nodeStatusResult = parallelNode.Execute();

            Assert.IsTrue(StatusIsFinished(nodeStatusResult),
                $"Did not finish. {nameof(nodeStatusResult)} = {nodeStatusResult}");
        }

        private bool StatusIsFinished(BehaviorNodeStatus status)
        {
            return (int)status > 1;
        }
    }
}
