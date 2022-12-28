using NUnit.Framework;

namespace BananaParty.BehaviorTree.Tests
{
    public class LimiterNodeTests
    {
        [Test]
        public void MustBeExecutedSpecifiedNumberOfTimes()
        {
            var invocationTestNode = new InvocationTestNode(BehaviorNodeStatus.Success);
            IBehaviorNode testNode = new LimiterNode(invocationTestNode, 2);

            var resultStatus = testNode.Execute();
            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Running);
            resultStatus = testNode.Execute();

            Assert.IsTrue(invocationTestNode.ExecutionCount == 2);
            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Success);
        }

        [Test]
        public void MustReturnFailureIfNodeRunning()
        {
            IBehaviorNode testNode = new LimiterNode(
                new InvocationTestNode(BehaviorNodeStatus.Running));

            var resultStatus = testNode.Execute();

            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Failure);
        }
    }
}
