using System;
using System.Diagnostics;
using NUnit.Framework;

namespace BananaParty.BehaviorTree.Tests
{
    public class PerformanceTests
    {
        private const int ObserverComparisonPerformanceTarget = 20;

        private const int ObjectCount = 1000;
        private const int FramesToRun = 1000;

        /// <summary>
        /// Measuring how Behavior Tree performance compares to Observer
        /// in a real-world use case of an OOP program.<br/>
        /// (Literally comparing running the entire tree to a single method call)
        /// </summary>
        /// <remarks>
        /// Behavior Tree is less performant, but still it has no allocations at run time (if you're into that... thing).<br/>
        /// So, Behavior Tree should not be used for objects with trivial behavior.<br/>
        /// <br/>
        /// Eventually you'll drown in bugs and complexity when using Observer for complex behavior though.<br/>
        /// </remarks>
        [Test]
        public void ShouldNotHavePerformanceRegression()
        {
            var behaviorObjects = new BehaviorObjectWithBoolean[ObjectCount];
            for (int behaviorObjectIterator = 0; behaviorObjectIterator < behaviorObjects.Length; behaviorObjectIterator += 1)
                behaviorObjects[behaviorObjectIterator] = new BehaviorObjectWithBoolean();

            var observerObjects = new ObserverObjectWithBoolean[ObjectCount];
            for (int observerObjectIterator = 0; observerObjectIterator < behaviorObjects.Length; observerObjectIterator += 1)
                observerObjects[observerObjectIterator] = new ObserverObjectWithBoolean();

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int frameNumber = 1; frameNumber <= FramesToRun; frameNumber += 1)
                foreach (ObserverObjectWithBoolean observerObject in observerObjects)
                    observerObject.Update(frameNumber);
            stopwatch.Stop();

            TimeSpan observerResult = stopwatch.Elapsed;

            stopwatch.Reset();

            stopwatch.Start();
            for (int frameNumber = 1; frameNumber <= FramesToRun; frameNumber += 1)
                foreach (BehaviorObjectWithBoolean behaviorObject in behaviorObjects)
                    behaviorObject.Update(frameNumber);
            stopwatch.Stop();

            TimeSpan behaviorResult = stopwatch.Elapsed;

            Assert.Less(behaviorResult, observerResult * ObserverComparisonPerformanceTarget, $"Performance regression. Behavior Tree should be less than {ObserverComparisonPerformanceTarget} times slower than Observer.");
        }

        private sealed class ObserverObjectWithBoolean
        {
            public event Action BooleanChangedEvent;

            public bool BooleanValue = false;

            public ObserverObjectWithBoolean()
            {
                BooleanChangedEvent += () => BooleanValue = false;
            }

            public void Update(int frameNumber)
            {
                if (frameNumber >= FramesToRun)
                {
                    BooleanValue = true;

                    // Implementation difference starts here

                    BooleanChangedEvent();
                }
            }
        }

        private sealed class BehaviorObjectWithBoolean
        {
            public bool BooleanValue = false;

            private readonly SequenceNode _behaviorTree;

            public BehaviorObjectWithBoolean()
            {
                _behaviorTree = new SequenceNode(new IBehaviorNode[]
                {
                    new WaitUntilBooleanIsTrueNode(this),
                    new SwitchBooleanToFalseNode(this)
                });
            }

            public void Update(int frameNumber)
            {
                if (frameNumber >= FramesToRun)
                    BooleanValue = true;

                // Implementation difference starts here

                _behaviorTree.Execute(frameNumber);
            }
        }

        private sealed class WaitUntilBooleanIsTrueNode : BehaviorNode
        {
            private readonly BehaviorObjectWithBoolean _behaviorObjectWithBoolean;

            public WaitUntilBooleanIsTrueNode(BehaviorObjectWithBoolean behaviorObjectWithBoolean)
            {
                _behaviorObjectWithBoolean = behaviorObjectWithBoolean;
            }

            public override BehaviorNodeStatus OnExecute(long time)
            {
                if (_behaviorObjectWithBoolean.BooleanValue)
                    return BehaviorNodeStatus.Success;
                else
                    return BehaviorNodeStatus.Running;
            }
        }

        private sealed class SwitchBooleanToFalseNode : BehaviorNode
        {
            private readonly BehaviorObjectWithBoolean _behaviorObjectWithBoolean;

            public SwitchBooleanToFalseNode(BehaviorObjectWithBoolean behaviorObjectWithBoolean)
            {
                _behaviorObjectWithBoolean = behaviorObjectWithBoolean;
            }

            public override BehaviorNodeStatus OnExecute(long time)
            {
                _behaviorObjectWithBoolean.BooleanValue = false;

                return BehaviorNodeStatus.Success;
            }
        }
    }
}
