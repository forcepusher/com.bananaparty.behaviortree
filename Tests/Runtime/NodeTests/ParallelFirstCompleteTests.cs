using NUnit.Framework;

namespace BananaParty.BehaviorTree.Tests
{
    public class ParallelFirstCompleteTests
    {
        [Test]
        public void ShouldFinishWhenFirstChildCompletes()
        {
            InvocationTest[] testNodes = new[]
            {
                new InvocationTest(NodeStatus.Running),
                new InvocationTest(NodeStatus.Running),
                new InvocationTest(NodeStatus.Running)
            };

            var parallelNode = new ParallelFirstComplete(testNodes);
            parallelNode.Execute(1);

            Assert.IsFalse(parallelNode.Status > NodeStatus.Running, $"Finished too early.");

            testNodes[1].Status = NodeStatus.Failure;

            parallelNode.Execute(2);

            Assert.IsTrue(parallelNode.Status > NodeStatus.Running, $"Did not finish. {nameof(parallelNode.Status)} = {parallelNode.Status}");
        }
    }
}
