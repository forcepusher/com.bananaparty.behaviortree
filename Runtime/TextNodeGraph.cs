using System;
using System.Collections.Generic;
using System.Text;

namespace BehaviorTree
{
    public class TextNodeGraph : INodeGraph
    {
        private readonly Dictionary<NodeExecutionStatus, string> _statusToString = new()
        {
            { NodeExecutionStatus.Idle, "-" },
            { NodeExecutionStatus.Failure, "F" },
            { NodeExecutionStatus.Success, "S" },
            { NodeExecutionStatus.Running, "R" }
        };

        private readonly StringBuilder _stringBuilder = new();
        private string _indentation = string.Empty;
        private readonly Stack<int> _childrenToDraw = new();

        private int CurrentChildrenToDrawCount
        {
            get
            {
                if (_childrenToDraw.Count > 0)
                    return _childrenToDraw.Peek();

                return 0;
            }
        }

        public void StartChildGroup(int childCount)
        {
            if (_childrenToDraw.Count > 0)
            {
                _indentation += CurrentChildrenToDrawCount > 0 ? "│ " : "  ";
            }
            else
            {
                // Adding empty line after the root node.
                _stringBuilder.Append('\n');
                _stringBuilder.Append('│');
            }

            _childrenToDraw.Push(childCount);
        }

        public void Write(string nodeInfo, NodeExecutionStatus nodeExecutionStatus)
        {
            if (_stringBuilder.Length > 0)
            {
                _stringBuilder.Append('\n');
                _stringBuilder.Append(_indentation);
                _stringBuilder.Append(CurrentChildrenToDrawCount > 1 ? "├╴" : "└╴");
            }

            _stringBuilder.Append($"{nodeInfo} {_statusToString[nodeExecutionStatus]}");

            if (_childrenToDraw.Count > 0)
            {
                _childrenToDraw.Push(_childrenToDraw.Pop() - 1);
            }
        }

        public void EndChildGroup()
        {
            _childrenToDraw.Pop();

            // Adding empty line after last child node.
            if (CurrentChildrenToDrawCount > 0)
            {
                _stringBuilder.Append('\n');
                _stringBuilder.Append(_indentation);
            }

            _indentation = _indentation.Substring(0, Math.Max(_indentation.Length - 2, 0));
        }

        public override string ToString()
        {
            return _stringBuilder.ToString();
        }
    }
}
