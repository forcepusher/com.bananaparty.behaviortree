namespace BehaviorTree
{
    public interface INodeGraph
    {
        public void StartChildGroup(int childCount);

        public void EndChildGroup(int childCount);

        public void Write(string nodeInfo, int runningChildNodeIndex = -1);
    }
}
