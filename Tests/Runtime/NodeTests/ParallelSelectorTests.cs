using NUnit.Framework;

namespace BananaParty.BehaviorTree.Tests
{
    public class ParallelSelectorTests
    {
        [Test]
        public void ShouldFinishWhenAnyChildrenCompletes()
        {
            InvocationTest[] testNodes = new[]
            {
                new InvocationTest(NodeStatus.Failure),
                new InvocationTest(NodeStatus.Running),
                new InvocationTest(NodeStatus.Running)
            };

            var parallelNode = new ParallelSelector(testNodes);
            parallelNode.Execute(1);

            Assert.IsFalse(parallelNode.Status > NodeStatus.Running, $"Finished too early.");

            testNodes[1].Status = NodeStatus.Success;

            parallelNode.Execute(2);

            Assert.IsTrue(parallelNode.Status > NodeStatus.Running, $"Did not finish. {nameof(parallelNode.Status)} = {parallelNode.Status}");
        }
    }
}
