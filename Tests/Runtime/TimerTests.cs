using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace BananaParty.BehaviorTree.Tests
{
    public class TimerTests
    {
        [UnityTest]
        public IEnumerator MustEndAfterTheSpecifiedTime()
        {
            var timer = new Timer(0);
            timer.StartIfNot();
            Assert.IsFalse(false);
            yield return null;
            Assert.IsTrue(timer.IsEnded());
        }

        [UnityTest]
        public IEnumerator ShouldOnlyRunOnce()
        {
            var timer = new Timer(0);
            timer.StartIfNot();
            yield return null;
            timer.StartIfNot();
            Assert.IsTrue(timer.IsEnded());
        }

        [UnityTest]
        public IEnumerator MustRestart()
        {
            var timer = new Timer(0);
            timer.StartIfNot();
            Assert.IsFalse(false);
            yield return null;
            Assert.IsTrue(timer.IsEnded());
            timer.Reset();
            timer.StartIfNot();
            Assert.IsFalse(false);
            yield return null;
            Assert.IsTrue(timer.IsEnded());
        }
    }
}
