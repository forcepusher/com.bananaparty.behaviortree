using NUnit.Framework;

namespace BananaParty.BehaviorTree.Tests
{
    public class TimeoutTests
    {
        private const float TimeoutThreshold = 1f;
        private const float SomeSmallThreshold = 0.001f;

        [Test]
        public void ShouldReturnExpectedResultOnTimeout()
        {
            ShouldReturnExpectedResultOnTimeout(NodeStatus.Success, NodeStatus.Failure);
            ShouldReturnExpectedResultOnTimeout(NodeStatus.Failure, NodeStatus.Failure);
            ShouldReturnExpectedResultOnTimeout(NodeStatus.Running, NodeStatus.Failure);
        }

        private void ShouldReturnExpectedResultOnTimeout(NodeStatus childStatus, NodeStatus finalStatus)
        {
            var timeoutNode = new Timeout
            (
                new Constant(childStatus),
                TimeoutThreshold
            );

            timeoutNode.Execute(TimeoutThreshold);

            Assert.AreEqual(timeoutNode.Status, finalStatus);
        }

        [Test]
        public void ShouldFailAndNotRestartOnTimeout()
        {
            ShouldFailAndNotRestartOnTimeout(NodeStatus.Success);
            ShouldFailAndNotRestartOnTimeout(NodeStatus.Failure);
            ShouldFailAndNotRestartOnTimeout(NodeStatus.Running);
        }

        private void ShouldFailAndNotRestartOnTimeout(NodeStatus status)
        {
            var statusChangingNode = new MutableConstant(NodeStatus.Running);
            var timeoutNode = new Timeout
            (
                statusChangingNode,
                TimeoutThreshold
            );

            timeoutNode.Execute(TimeoutThreshold);

            statusChangingNode.NextExecutionStatus = status;
            timeoutNode.Execute(TimeoutThreshold + SomeSmallThreshold);

            Assert.AreEqual(timeoutNode.Status, NodeStatus.Failure);
        }
    }
}
