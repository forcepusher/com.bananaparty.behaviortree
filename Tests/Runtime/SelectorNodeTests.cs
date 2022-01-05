using System.Linq;
using NUnit.Framework;

namespace BehaviorTree.Tests
{
    public class SelectorNodeTests
    {
        [Test]
        public void ShouldExecuteAllChildrenOnce()
        {
            InvocationTestNode[] testNodes = new[]
            {
                new InvocationTestNode(NodeExecutionStatus.Failure),
                new InvocationTestNode(NodeExecutionStatus.Failure),
                new InvocationTestNode(NodeExecutionStatus.Failure)
            };

            var sequence = new SelectorNode(testNodes);
            sequence.Execute(long.MaxValue);

            Assert.IsTrue(testNodes.All(testNode => testNode.ExecutionCount == 1));
        }
    }
}
