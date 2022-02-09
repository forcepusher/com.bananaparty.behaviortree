using NUnit.Framework;

namespace BananaParty.BehaviorTree.Tests
{
    public class TimeoutNodeTests
    {
        private const long TimeoutThreshold = 1000;
        private const long SomeSmallThreshold = 1;

        [Test]
        public void ShouldReturnExpectedResultOnTimeout()
        {
            ShouldReturnExpectedResultOnTimeout(BehaviorNodeStatus.Success, BehaviorNodeStatus.Success);
            ShouldReturnExpectedResultOnTimeout(BehaviorNodeStatus.Failure, BehaviorNodeStatus.Failure);
            ShouldReturnExpectedResultOnTimeout(BehaviorNodeStatus.Running, BehaviorNodeStatus.Failure);
        }

        private void ShouldReturnExpectedResultOnTimeout(BehaviorNodeStatus childStatus, BehaviorNodeStatus finalStatus)
        {
            var timeoutNode = new TimeoutNode
            (
                new ConstantNode(childStatus),
                TimeoutThreshold
            );

            // Warm-up from Idle state, should update start time
            timeoutNode.Execute(0);
            timeoutNode.Execute(TimeoutThreshold);

            Assert.AreEqual(timeoutNode.Status, finalStatus);
        }

        [Test]
        public void ShouldRestartWhenChildStartsRunningAfterFinishing()
        {
            ShouldRestartWhenChildStartsRunningAfterFinishing(BehaviorNodeStatus.Success);
            ShouldRestartWhenChildStartsRunningAfterFinishing(BehaviorNodeStatus.Failure);
        }

        private void ShouldRestartWhenChildStartsRunningAfterFinishing(BehaviorNodeStatus finishedStatus)
        {
            var statusChangingNode = new MutableConstantNode(finishedStatus);
            var timeoutNode = new TimeoutNode
            (
                statusChangingNode,
                TimeoutThreshold
            );

            // Warm-up from Idle state, should update start time
            timeoutNode.Execute(0);
            timeoutNode.Execute(TimeoutThreshold);

            statusChangingNode.NextExecutionStatus = BehaviorNodeStatus.Running;
            timeoutNode.Execute(TimeoutThreshold + SomeSmallThreshold);

            Assert.AreEqual(timeoutNode.Status, BehaviorNodeStatus.Running);
        }

        [Test]
        public void ShouldFailAndNotRestartOnTimeout()
        {
            ShouldFailAndNotRestartOnTimeout(BehaviorNodeStatus.Success);
            ShouldFailAndNotRestartOnTimeout(BehaviorNodeStatus.Failure);
            ShouldFailAndNotRestartOnTimeout(BehaviorNodeStatus.Running);
        }

        private void ShouldFailAndNotRestartOnTimeout(BehaviorNodeStatus status)
        {
            var statusChangingNode = new MutableConstantNode(BehaviorNodeStatus.Running);
            var timeoutNode = new TimeoutNode
            (
                statusChangingNode,
                TimeoutThreshold
            );

            // Warm-up from Idle state, should update start time
            timeoutNode.Execute(0);
            timeoutNode.Execute(TimeoutThreshold);

            statusChangingNode.NextExecutionStatus = status;
            timeoutNode.Execute(TimeoutThreshold + SomeSmallThreshold);

            Assert.AreEqual(timeoutNode.Status, BehaviorNodeStatus.Failure);
        }
    }
}
