using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;

namespace BananaParty.BehaviorTree.Tests
{
    public class TimeoutNodeTests
    {
        [UnityTest]
        public IEnumerator MustEndAfterTheSpecifiedTime()
        {
            var timeOutNode = new TimeoutNode(
                new InvocationTestNode(BehaviorNodeStatus.Success),
                new Timer(0));

            var result = timeOutNode.Execute();
            Assert.IsTrue(result == BehaviorNodeStatus.Running);
            yield return null;
            result = timeOutNode.Execute();
            Assert.IsTrue(result == BehaviorNodeStatus.Success);
        }

        [UnityTest]
        public IEnumerator MustReturnFailureIfNodeHasNotEnded()
        {
            var timeOutNode = new TimeoutNode(
                new InvocationTestNode(BehaviorNodeStatus.Running),
                new Timer(0));

            var result = timeOutNode.Execute();
            Assert.IsTrue(result == BehaviorNodeStatus.Running);
            yield return null;
            result = timeOutNode.Execute();
            Assert.IsTrue(result == BehaviorNodeStatus.Failure);
        }
    }
}
