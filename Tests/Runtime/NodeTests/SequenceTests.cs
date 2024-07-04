using System.Linq;
using NUnit.Framework;

namespace BananaParty.BehaviorTree.Tests
{
    public class SequenceTests
    {
        [Test]
        public void ShouldExecuteAllChildrenOnce()
        {
            InvocationTest[] testNodes = new[]
            {
                new InvocationTest(NodeStatus.Success),
                new InvocationTest(NodeStatus.Success),
                new InvocationTest(NodeStatus.Success)
            };

            var sequence = new Sequence(testNodes);
            sequence.Execute(long.MaxValue);

            Assert.IsTrue(testNodes.All(testNode => testNode.ExecutionCount == 1));
        }

        [Test]
        public void ShouldReevaluateConditionals()
        {
            var reevaluatedCondition = new InvocationTest(NodeStatus.Success);

            var sequence = new ReactiveSequence(new INode[]
            {
                reevaluatedCondition,
                new InvocationTest(NodeStatus.Running)
            });

            sequence.Execute(0);

            Assert.IsTrue(reevaluatedCondition.ExecutionCount == 1);
        }

        [Test]
        public void ShouldReevaluateConditionalsInComplexHierarchy()
        {
            var firstReevaluatedCondition = new InvocationTest(NodeStatus.Success);
            var secondReevaluatedCondition = new InvocationTest(NodeStatus.Success);

            var sequence = new ReactiveSequence(new INode[]
            {
                firstReevaluatedCondition,
                secondReevaluatedCondition,
                new Repeat
                (
                    new Sequence(new INode[]
                    {
                        new Wait(700),
                        new InvocationTest(NodeStatus.Running)
                    })
                ),
            });

            sequence.Execute(0);
            sequence.Execute(0);
            sequence.Execute(0);

            Assert.IsTrue(firstReevaluatedCondition.ExecutionCount == 3);
            Assert.IsTrue(secondReevaluatedCondition.ExecutionCount == 3);
        }

        [Test]
        public void ShouldResetChildrenOnInterrupt()
        {
            var condition = new MutableConstant(NodeStatus.Success);
            var invocationTest = new InvocationTest(NodeStatus.Success);

            var behavior =
            new ReactiveSequence(new INode[]
            {
                condition,
                invocationTest
            });

            behavior.Execute(1);

            OutputGraph(behavior);

            Assert.AreEqual(invocationTest.ExecutionCount, 1);

            condition.NextExecutionStatus = NodeStatus.Failure;

            behavior.Execute(2);

            OutputGraph(behavior);

            Assert.AreEqual(invocationTest.ExecutionCount, 1);
            Assert.AreEqual(NodeStatus.Idle, invocationTest.Status);
        }

        private void OutputGraph(INode behavior)
        {
            var textGraph = new TextTreeGraph("Test");
            behavior.WriteToGraph(textGraph);
        }
    }
}
