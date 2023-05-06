using System.Linq;
using NUnit.Framework;

namespace BananaParty.BehaviorTree.Tests
{
    public class SequenceRollbackNodeTests
    {
        [Test]
        public void ShouldExecuteAllChildrenOnce()
        {
            // TODO: Test it

            //IRollbackNode _rollbackBehavior = new SequenceRollbackNode(new IRollbackNode[]
            //{
            //    new ConstantRollbackNode(BehaviorNodeStatus.Success)
            //});

            //ISnapshotTree snapshotTree = new SnapshotTree();
            //_rollbackBehavior.WriteState(snapshotTree);
            //snapshotTree.ApplyState();

            Assert.Pass();
        }
    }
}
