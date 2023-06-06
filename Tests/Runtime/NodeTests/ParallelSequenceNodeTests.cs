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
            parallelNode.Execute(1);

            Assert.IsFalse(parallelNode.Status > BehaviorNodeStatus.Running, $"Finished too early.");

            testNodes[0].Status = BehaviorNodeStatus.Success;
            testNodes[2].Status = BehaviorNodeStatus.Success;

            parallelNode.Execute(2);

            Assert.IsTrue(parallelNode.Status > BehaviorNodeStatus.Running, $"Did not finish. {nameof(parallelNode.Status)} = {parallelNode.Status}");
        }
    }
}
