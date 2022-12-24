using System.Collections.Generic;

namespace BananaParty.BehaviorTree
{
    public class TextBehaviorTreeVisualizer : IBehaviorTreeVisualizer
    {
        private ITextDisplay _display;
        private INodeDataTextVisualizer _nodeVisualizer;
        private string _currentBranch = string.Empty;
        private List<string> _branches = new List<string>();
        private bool _treeIsNotGenerated = true;
        private bool _dontDisplayChains;

        public TextBehaviorTreeVisualizer(ITextDisplay display, INodeDataTextVisualizer nodeVisualizer, bool dontDisplayChains = true)
        {
            _display = display;
            _nodeVisualizer = nodeVisualizer;
            _dontDisplayChains = dontDisplayChains;
        }

        public void Visualize(BehaviorNodeVisualizationData nodeData)
        {
            if (_treeIsNotGenerated)
            {
                GenerateTree(nodeData);
                _treeIsNotGenerated = false;
            }
            string result = _nodeVisualizer.DisplayRoot() + '\n';
            result += DisplayNodes(nodeData, _branches.GetEnumerator());
            _display.Display(result);
        }

        private void GenerateTree(BehaviorNodeVisualizationData node)
        {
            if (!CanDisplay(node))
            {
                if (node.NextNode != null)
                {
                    _branches.Add(_currentBranch + DisplayMiddleBranch().ToString());
                    if (node.ChildNode.ChildNode != null)
                    {
                        AddLevel(DisplayPassBranch());
                        GenerateTree(node.ChildNode.ChildNode);
                        RemoveLevel();
                    }
                    GenerateTree(node.NextNode);
                }
                else
                {
                    _branches.Add(_currentBranch + DisplayLastBranch().ToString());
                    if (node.ChildNode.ChildNode != null)
                    {
                        AddLevel(DisplayEmptyBranch());
                        GenerateTree(node.ChildNode.ChildNode);
                        RemoveLevel();
                    }
                }
                return;
            }

            if (node.NextNode != null)
            {
                _branches.Add(_currentBranch + DisplayMiddleBranch().ToString());
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
                _branches.Add(_currentBranch + DisplayLastBranch().ToString());
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
            string result = string.Empty;

            if (CanDisplay(node))
            {
                tree.MoveNext();
                var currentBranch = tree.Current;
                result = currentBranch + _nodeVisualizer.Display(node) + '\n';
            }
            if (node.ChildNode != null) result += DisplayNodes(node.ChildNode, tree);
            if (node.NextNode != null) result += DisplayNodes(node.NextNode, tree);
            return result;
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

        private bool CanDisplay(BehaviorNodeVisualizationData node)
        {
            return !(_dontDisplayChains && node.Type == BehaviorNodeType.Chain);
        }
    }
}
