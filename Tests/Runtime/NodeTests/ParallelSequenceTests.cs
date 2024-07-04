using NUnit.Framework;

namespace BananaParty.BehaviorTree.Tests
{
    public class ParallelSequenceTests
    {
        [Test]
        public void ShouldFinishWhenAllChildrenComplete()
        {
            InvocationTest[] testNodes = new[]
            {
                new InvocationTest(NodeStatus.Running),
                new InvocationTest(NodeStatus.Success),
                new InvocationTest(NodeStatus.Running)
            };

            var parallelNode = new ParallelSequence(testNodes);
            parallelNode.Execute(1);

            Assert.IsFalse(parallelNode.Status > NodeStatus.Running, $"Finished too early.");

            testNodes[0].Status = NodeStatus.Success;
            testNodes[2].Status = NodeStatus.Success;

            parallelNode.Execute(2);

            Assert.IsTrue(parallelNode.Status > NodeStatus.Running, $"Did not finish. {nameof(parallelNode.Status)} = {parallelNode.Status}");
        }
    }
}
