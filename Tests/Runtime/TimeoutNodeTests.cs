using NUnit.Framework;

namespace BananaParty.BehaviorTree.Tests
{
    public class TimeoutNodeTests
    {
        private const long TimeoutThreshold = 1000;
        private const long SomeSmallThreshold = 1;

        [TestCase(BehaviorNodeStatus.Success, BehaviorNodeStatus.Success)]
        [TestCase(BehaviorNodeStatus.Failure, BehaviorNodeStatus.Failure)]
        [TestCase(BehaviorNodeStatus.Running, BehaviorNodeStatus.Failure)]
        public void ShouldReturnExpectedResultOnTimeout(BehaviorNodeStatus childStatus, BehaviorNodeStatus finalStatus)
        {
            TimeoutNode timeoutNode = new TimeoutNode
            (
                new ConstantNode(childStatus),
                TimeoutThreshold
            );

            // Warm-up from Idle state, should update start time
            timeoutNode.Execute(0);
            timeoutNode.Execute(TimeoutThreshold);

            Assert.IsTrue(timeoutNode.Status == finalStatus);
        }

        [TestCase(BehaviorNodeStatus.Success)]
        [TestCase(BehaviorNodeStatus.Failure)]
        public void ShouldRestartWhenChildStartsRunningAfterFinishing(BehaviorNodeStatus finishedStatus)
        {
            var statusChangingNode = new MutableConstantNode(finishedStatus);
            TimeoutNode timeoutNode = new TimeoutNode
            (
                statusChangingNode,
                TimeoutThreshold
            );

            // Warm-up from Idle state, should update start time
            timeoutNode.Execute(0);
            timeoutNode.Execute(TimeoutThreshold);

            statusChangingNode.NextExecutionStatus = BehaviorNodeStatus.Running;
            timeoutNode.Execute(TimeoutThreshold + SomeSmallThreshold);

            Assert.IsTrue(timeoutNode.Status == BehaviorNodeStatus.Running);
        }

        [TestCase(BehaviorNodeStatus.Success)]
        [TestCase(BehaviorNodeStatus.Failure)]
        [TestCase(BehaviorNodeStatus.Running)]
        public void ShouldFailAndNotRestartOnTimeout(BehaviorNodeStatus anyStatus)
        {
            var statusChangingNode = new MutableConstantNode(BehaviorNodeStatus.Running);
            TimeoutNode timeoutNode = new TimeoutNode
            (
                statusChangingNode,
                TimeoutThreshold
            );

            // Warm-up from Idle state, should update start time
            timeoutNode.Execute(0);
            timeoutNode.Execute(TimeoutThreshold);

            statusChangingNode.NextExecutionStatus = anyStatus;
            timeoutNode.Execute(TimeoutThreshold + SomeSmallThreshold);

            Assert.IsTrue(timeoutNode.Status == BehaviorNodeStatus.Failure);
        }
    }
}
