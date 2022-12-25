namespace BananaParty.BehaviorTree
{
    /// <summary>
    /// Displays the specified node as text.
    /// </summary>
    public class TextNodeDataVisualizer : INodeDataTextVisualizer
    {
        public string Display(BehaviorNodeVisualizationData node)
        {
            var type = DisplayType(node.Type);
            var state = DisplayStatus(node.State);
            var name = node.Name;

            if (string.IsNullOrEmpty(type))
            {
                return $"<{state}> {name}";
            }

            return $"<{type} - {state}> {name}";
        }

        public string DisplayRoot()
        {
            return "Root";
        }

        private string DisplayType(BehaviorNodeType type)
        {
            return type switch
            {
                BehaviorNodeType.Sequence => "S",
                BehaviorNodeType.Selector => "F",
                BehaviorNodeType.ParallelSequence => "&S",
                BehaviorNodeType.ParallelSelector => "&F",
                _ => string.Empty,
            };
        }

        private string DisplayStatus(BehaviorNodeStatus status)
        {
            return status switch
            {
                BehaviorNodeStatus.Success => "Done",
                BehaviorNodeStatus.Failure => "Fail",
                BehaviorNodeStatus.Running => "Run",
                _ => "Idle",
            };
        }
    }
}
