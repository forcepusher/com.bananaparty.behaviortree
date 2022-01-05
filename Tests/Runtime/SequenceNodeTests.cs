using System.Linq;
using NUnit.Framework;

namespace BehaviorTree.Tests
{
    public class SequenceNodeTests
    {
        [Test]
        public void ShouldExecuteAllChildrenOnce()
        {
            InvocationTestNode[] testNodes = new[]
            {
                new InvocationTestNode(NodeExecutionStatus.Success),
                new InvocationTestNode(NodeExecutionStatus.Success),
                new InvocationTestNode(NodeExecutionStatus.Success)
            };

            var sequence = new SequenceNode(testNodes);
            sequence.Execute(long.MaxValue);

            Assert.IsTrue(testNodes.All(testNode => testNode.ExecutionCount == 1));
        }
    }
}
