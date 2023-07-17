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

        [Test]
        public void ShouldReevaluateConditionals()
        {
            var reevaluatedCondition = new InvocationTestNode(BehaviorNodeStatus.Success);

            var sequence = new ReactiveSequenceNode(new IBehaviorNode[]
            {
                reevaluatedCondition,
                new InvocationTestNode(BehaviorNodeStatus.Running)
            });

            sequence.Execute(0);

            Assert.IsTrue(reevaluatedCondition.ExecutionCount == 1);
        }

        [Test]
        public void ShouldReevaluateConditionalsInComplexHierarchy()
        {
            var firstReevaluatedCondition = new InvocationTestNode(BehaviorNodeStatus.Success);
            var secondReevaluatedCondition = new InvocationTestNode(BehaviorNodeStatus.Success);

            var sequence = new ReactiveSequenceNode(new IBehaviorNode[]
            {
                firstReevaluatedCondition,
                secondReevaluatedCondition,
                new RepeatNode
                (
                    new SequenceNode(new IBehaviorNode[]
                    {
                        new WaitNode(700),
                        new InvocationTestNode(BehaviorNodeStatus.Running)
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
            var condition = new MutableConstantNode(BehaviorNodeStatus.Success);
            var invocationTest = new InvocationTestNode(BehaviorNodeStatus.Success);

            var behavior =
            new ReactiveSequenceNode(new IBehaviorNode[]
            {
                condition,
                invocationTest
            });

            behavior.Execute(1);

            OutputGraph(behavior);

            Assert.AreEqual(invocationTest.ExecutionCount, 1);

            condition.NextExecutionStatus = BehaviorNodeStatus.Failure;

            behavior.Execute(2);

            OutputGraph(behavior);

            Assert.AreEqual(invocationTest.ExecutionCount, 1);
            Assert.AreEqual(BehaviorNodeStatus.Idle, invocationTest.Status);
        }

        private void OutputGraph(IBehaviorNode behavior)
        {
            var textGraph = new TextBehaviorTreeGraph("Test");
            behavior.WriteToGraph(textGraph);
            UnityEngine.Debug.Log(textGraph);
        }
    }
}
