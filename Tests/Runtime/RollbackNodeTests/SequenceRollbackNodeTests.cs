using NUnit.Framework;

namespace BananaParty.BehaviorTree.Tests
{
    public class SequenceRollbackNodeTests
    {
        [Test]
        public void ShouldRollbackNodeStatus()
        {
            var rollbackNodeOne = new MementoTestRollbackNode(BehaviorNodeStatus.Idle, BehaviorNodeStatus.Success);
            var rollbackNodeTwo = new MementoTestRollbackNode(BehaviorNodeStatus.Idle, BehaviorNodeStatus.Running);
            var rollbackNodeThree = new MementoTestRollbackNode(BehaviorNodeStatus.Idle, BehaviorNodeStatus.Success);

            IRollbackNode _rollbackBehavior = new SequenceRollbackNode(new IRollbackNode[]
            {
                rollbackNodeOne,
                rollbackNodeTwo,
                rollbackNodeThree
            });

            ISnapshotTree snapshotTree = new SnapshotTree();
            _rollbackBehavior.WriteState(snapshotTree);

            _rollbackBehavior.Execute(0);

            Assert.That(rollbackNodeOne.Status, Is.EqualTo(BehaviorNodeStatus.Success), "Initial execution");
            Assert.That(rollbackNodeTwo.Status, Is.EqualTo(BehaviorNodeStatus.Running), "Initial execution");
            Assert.That(rollbackNodeThree.Status, Is.EqualTo(BehaviorNodeStatus.Idle), "Initial execution");

            snapshotTree.ApplyState();

            Assert.That(rollbackNodeOne.Status, Is.EqualTo(BehaviorNodeStatus.Idle), "Rollback to snapshot");
            Assert.That(rollbackNodeTwo.Status, Is.EqualTo(BehaviorNodeStatus.Idle), "Rollback to snapshot");
            Assert.That(rollbackNodeThree.Status, Is.EqualTo(BehaviorNodeStatus.Idle), "Rollback to snapshot");
        }
    }
}
