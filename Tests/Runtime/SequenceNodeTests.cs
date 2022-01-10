using System.Linq;
using NUnit.Framework;

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

            var sequence = new SequenceNode(testNodes);
            sequence.Execute(long.MaxValue);

            Assert.IsTrue(testNodes.All(testNode => testNode.ExecutionCount == 1));
        }
    }
}
