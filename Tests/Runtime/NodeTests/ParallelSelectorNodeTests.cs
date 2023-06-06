using NUnit.Framework;

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
            parallelNode.Execute(1);

            Assert.IsFalse(parallelNode.Status > BehaviorNodeStatus.Running, $"Finished too early.");

            testNodes[1].Status = BehaviorNodeStatus.Success;

            parallelNode.Execute(2);

            Assert.IsTrue(parallelNode.Status > BehaviorNodeStatus.Running, $"Did not finish. {nameof(parallelNode.Status)} = {parallelNode.Status}");
        }
    }
}
