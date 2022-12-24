using Codice.Client.Common.TreeGrouper;

namespace BananaParty.BehaviorTree
{
    public class TextColoredEmojiNodeDataVisualizer : INodeDataTextVisualizer
    {
        // To display this in Unity you can use FontAwesome as Fallback Font Asset
        public string Display(BehaviorNodeVisualizationData node)
        {
            var color = DisplayColor(node.State);
            var displayedNode = DisplayNode(node);
            if (string.IsNullOrEmpty(color)) return displayedNode;
            return $"<color={color}>{displayedNode}</color>";
        }

        public string DisplayRoot()
        {
            return "\uf05e Root Node";
        }

        private string DisplayType(BehaviorNodeType type)
        {
            return type switch
            {
                BehaviorNodeType.Sequence => "\uf0a9",
                BehaviorNodeType.Selector => "\uf059",
                BehaviorNodeType.ParallelSequence => "\ue4c2\uf0a9",
                BehaviorNodeType.ParallelSelector => "\ue4c2\uf059",
                BehaviorNodeType.Chain => "\uf0c1",
                BehaviorNodeType.Decorator => "\uf06b",
                _ => string.Empty,
            };
        }

        private string DisplayStatus(BehaviorNodeStatus status)
        {
            return status switch
            {
                BehaviorNodeStatus.Success => "\u2705",
                BehaviorNodeStatus.Failure => "\u274E",
                BehaviorNodeStatus.Running => "\U0001F504",
                _ => string.Empty,
            };
        }

        private string DisplayColor(BehaviorNodeStatus status)
        {
            return status switch
            {
                BehaviorNodeStatus.Success => "#40BC93",
                BehaviorNodeStatus.Failure => "#F83D35",
                BehaviorNodeStatus.Running => "#418AB3",
                _ => string.Empty,
            };
        }

        private string DisplayNode(BehaviorNodeVisualizationData node)
        {
            var type = DisplayType(node.Type);
            var state = DisplayStatus(node.State);
            var name = node.Name;

            var stateIsNull = string.IsNullOrEmpty(state);
            var typeIsNull = string.IsNullOrEmpty(type);

            if (stateIsNull && typeIsNull)
                return $" {name}";

            if (stateIsNull)
                return $" {type} {name}";

            if (typeIsNull)
                return $" {state} {name}";

            return $" {type} {state} {name}";
        }
    }
}
