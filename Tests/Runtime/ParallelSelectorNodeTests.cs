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
            var nodeStatusResult = parallelNode.Execute();

            Assert.IsFalse(StatusIsFinished(nodeStatusResult), $"Finished too early.");

            testNodes[1].Status = BehaviorNodeStatus.Success;

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
