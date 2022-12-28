using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaParty.BehaviorTree.Tests
{
    public class RepeatNodeTests
    {
        [Test]
        public void MustBeRepeatWhenSuccess()
        {
            IBehaviorNode testNode = new RepeatNode(
                new InvocationTestNode(BehaviorNodeStatus.Success),
                BehaviorNodeFinishStatus.Failure);

            var resultStatus = testNode.Execute();

            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Running);
        }

        [Test]
        public void MustBeRepeatWhenFailure()
        {
            IBehaviorNode testNode = new RepeatNode(
                new InvocationTestNode(BehaviorNodeStatus.Failure),
                BehaviorNodeFinishStatus.Success);

            var resultStatus = testNode.Execute();

            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Running);
        }

        [Test]
        public void MustBeStopWhenSuccess()
        {
            var InvocationTestNode = new InvocationTestNode(BehaviorNodeStatus.Failure);
            IBehaviorNode testNode = new RepeatNode(
                InvocationTestNode,
                BehaviorNodeFinishStatus.Success);

            var resultStatus = testNode.Execute();
            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Running);

            InvocationTestNode.ResultStatus = BehaviorNodeStatus.Success;
            resultStatus = testNode.Execute();

            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Success);
        }

        [Test]
        public void MustBeStopWhenFailure()
        {
            var InvocationTestNode = new InvocationTestNode(BehaviorNodeStatus.Success);
            IBehaviorNode testNode = new RepeatNode(
                InvocationTestNode,
                BehaviorNodeFinishStatus.Failure);

            var resultStatus = testNode.Execute();
            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Running);

            InvocationTestNode.ResultStatus = BehaviorNodeStatus.Failure;
            resultStatus = testNode.Execute();

            Assert.IsTrue(resultStatus == BehaviorNodeStatus.Failure);
        }
    }
}
