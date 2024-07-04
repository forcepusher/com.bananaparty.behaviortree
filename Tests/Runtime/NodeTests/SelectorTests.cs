using System.Linq;
using NUnit.Framework;

namespace BananaParty.BehaviorTree.Tests
{
    public class SelectorTests
    {
        [Test]
        public void ShouldExecuteAllChildrenOnce()
        {
            InvocationTest[] testNodes = new[]
            {
                new InvocationTest(NodeStatus.Failure),
                new InvocationTest(NodeStatus.Failure),
                new InvocationTest(NodeStatus.Failure)
            };

            var selector = new Selector(testNodes);
            selector.Execute(long.MaxValue);

            Assert.IsTrue(testNodes.All(testNode => testNode.ExecutionCount == 1));
        }
    }
}
