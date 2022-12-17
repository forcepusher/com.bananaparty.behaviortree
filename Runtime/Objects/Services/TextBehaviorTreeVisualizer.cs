using System.Collections.Generic;

namespace BananaParty.BehaviorTree
{
    public class TextBehaviorTreeVisualizer : INodeVisualizer
    {
        private ITextDisplay _display;
        private string _currentBranch = string.Empty;
        private List<string> _branches = new List<string>();
        private bool _treeIsNotGenerated = true;

        public TextBehaviorTreeVisualizer(ITextDisplay display)
        {
            _display = display;
        }

        public void Visualize(BehaviorNodeVisualizationData nodeData)
        {
            if (_treeIsNotGenerated)
            {
                GenerateTree(nodeData);
                _treeIsNotGenerated = false;
            }
            string result = DisplayRootNode();
            result += DisplayNodes(nodeData, _branches.GetEnumerator());
            _display.Display(result);
        }

        private void GenerateTree(BehaviorNodeVisualizationData node)
        {
            if (node.NextNode != null)
            {
                _branches.Add(DisplayMiddleBranch().ToString());
                if (node.ChildNode != null)
                {
                    AddLevel(DisplayPassBranch());
                    GenerateTree(node.ChildNode);
                    RemoveLevel();
                }
                GenerateTree(node.NextNode);
            }
            else
            {
                _branches.Add(DisplayLastBranch().ToString());
                if (node.ChildNode != null)
                {
                    AddLevel(DisplayEmptyBranch());
                    GenerateTree(node.ChildNode);
                    RemoveLevel();
                }
            }
        }

        private string DisplayNodes(BehaviorNodeVisualizationData node, IEnumerator<string> tree)
        {
            tree.MoveNext();
            var currentBranch = tree.Current;
            string result = $"{currentBranch}<{DisplayType(node.Type)}" +
                $"-{DisplayStatus(node.State)}> {node.Name}\n";
            if (node.ChildNode != null) result += DisplayNodes(node.ChildNode, tree);
            if (node.NextNode != null) result += DisplayNodes(node.NextNode, tree);
            return result;
        }

        private string DisplayType(BehaviorNodeType type)
        {
            return type switch
            {
                BehaviorNodeType.Sequence => "➩",
                BehaviorNodeType.Selector => "?",
                BehaviorNodeType.ParallelSequence => "&➩",
                BehaviorNodeType.ParallelSelector => "&?",
                _ => string.Empty,
            };
        }

        private string DisplayStatus(BehaviorNodeStatus status)
        {
            return status switch
            {
                BehaviorNodeStatus.Success => "✅",
                BehaviorNodeStatus.Failure => "❎",
                BehaviorNodeStatus.Running => "🔄",
                _ => "⏸",
            };
        }

        private string DisplayRootNode()
        {
            return "<Ø> Root Node\n";
        }

        private char DisplayMiddleBranch() => '├';

        private char DisplayLastBranch() => '└';
        private char DisplayPassBranch() => '│';
        private char DisplayEmptyBranch() => ' ';

        private void AddLevel(char symbol)
        {
            _currentBranch = string.Concat(_currentBranch, symbol);
        }

        private void RemoveLevel()
        {
            if (_currentBranch.Length <= 0) return;
            _currentBranch = _currentBranch.Remove(_currentBranch.Length - 1);
        }
    }
}
