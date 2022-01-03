namespace BehaviorTree
{
    public interface INodeGraph
    {
        public void StartChildGroup(int childCount);

        public void Write(string nodeInfo, int runningChildIndex = -1);

        public void EndChildGroup();
    }
}
