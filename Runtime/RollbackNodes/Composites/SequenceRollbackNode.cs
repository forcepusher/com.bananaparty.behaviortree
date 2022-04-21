namespace BananaParty.BehaviorTree
{
    public class SequenceRollbackNode : SequenceNode, IRollbackNode
    {
        private readonly IRollbackNode[] _childNodes;
        private readonly bool _alwaysReevaluate;
        private readonly string _descriptionPrefix;

        public SequenceRollbackNode(IRollbackNode[] childNodes, bool alwaysReevaluate = false, string descriptionPrefix = "") : base(childNodes, alwaysReevaluate, descriptionPrefix)
        {
            _childNodes = childNodes;
            _alwaysReevaluate = alwaysReevaluate;
            _descriptionPrefix = descriptionPrefix;
        }

        public IRollbackNode Copy()
        {
            var childNodesCopy = new IRollbackNode[_childNodes.Length];
            for (int i = 0; i < childNodesCopy.Length; ++i)
                childNodesCopy[i] = _childNodes[i].Copy();

            var nodeCopy = new SequenceRollbackNode(childNodesCopy, _alwaysReevaluate, _descriptionPrefix);
            nodeCopy.Status = Status;
            
            return nodeCopy;
        }
    }
}
