namespace BehaviorTree
{
    public interface INodeGraph
    {
        public void StartChildGroup(int childCount);

        public void Write(string nodeInfo, NodeExecutionStatus nodeExecutionStatus);

        public void EndChildGroup();
    }
}
