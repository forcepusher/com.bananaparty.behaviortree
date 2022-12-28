using NUnit.Framework;

namespace BananaParty.BehaviorTree.Tests
{
    public class InverterNodeTests
    {
        [Test]
        public void MustBeReturnFailure()
        {
            IBehaviorNode testNode = new InverterNode(
                new InvocationTestNode(BehaviorNodeStatus.Success));

            var resultStatus = testNode.Execute();

            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Failure);
        }

        [Test]
        public void MustBeReturnSuccess()
        {
            IBehaviorNode testNode = new InverterNode(
                new InvocationTestNode(BehaviorNodeStatus.Failure));

            var resultStatus = testNode.Execute();

            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Success);
        }
    }
}
