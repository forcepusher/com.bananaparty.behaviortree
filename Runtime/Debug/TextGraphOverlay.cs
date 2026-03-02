using System.Collections.Generic;
using System.Text;
using BananaParty.BehaviorTree;
using UnityEngine;

public class TextGraphOverlay : MonoBehaviour
{
    private const bool DefaultVisible = true;
    private const KeyCode DefaultToggleButton = KeyCode.Home;
    private const string DefaultBehaviorTreeName = "BehaviorTree";

    [field: SerializeField]
    public bool Visible { get; set; } = DefaultVisible;
    [field: SerializeField]
    public KeyCode ToggleButton { get; set; } = DefaultToggleButton;

    [Space]

    [SerializeField]
    private int _textWindowLineSize = 20;
    [SerializeField]
    private int _textPageLineSize = 10;

    private GUIStyle _guiStyle;
    
    private int _textPageNumber = 0;
    private int _lastTextLineCount = 0;

    private readonly List<BehaviorTree> _behaviorTrees = new();

    private void Awake()
    {
        _guiStyle = new GUIStyle { font = Resources.Load<Font>("TextGraphDebugFont") };
        _guiStyle.normal.textColor = Color.white;
    }

    private void Update()
    {
        if (Input.GetKeyDown(ToggleButton))
            Visible = !Visible;

        if (!Visible)
            return;

        if (Input.GetKeyDown(KeyCode.PageDown))
            _textPageNumber = Mathf.Max(0, Mathf.Min(_textPageNumber + 1, _lastTextLineCount / _textPageLineSize - 1));
        else if (Input.GetKeyDown(KeyCode.PageUp))
            _textPageNumber = Mathf.Max(0, _textPageNumber - 1);
    }

    private void OnGUI()
    {
        if (!Visible)
            return;

        StringBuilder completeGraph = new();

        for (int behaviorTreeIndex = 0; behaviorTreeIndex < _behaviorTrees.Count; behaviorTreeIndex += 1)
        {
            BehaviorTree behaviorTree = _behaviorTrees[behaviorTreeIndex];
            if (behaviorTree != null)
            {
                var textGraph = new TextTreeGraph(behaviorTree.Name);
                behaviorTree.RootNode.WriteToGraph(textGraph);
                completeGraph.Append(textGraph.ToString());

                if (behaviorTreeIndex < _behaviorTrees.Count - 1)
                    completeGraph.Append("\n\n");
            }
        }

        DrawText(completeGraph.ToString(), transform.position);
    }

    private void DrawText(string text, Vector3 worldPosition)
    {
        DrawText(text, (Vector2)Camera.main.WorldToScreenPoint(worldPosition));
    }

    private void DrawText(string text, Vector2 screenPosition)
    {
        string[] splitText = text.Split('\n');
        _lastTextLineCount = splitText.Length;
        
        if (splitText.Length == 0)
            return;
        
        int startLine = _textPageNumber * _textPageLineSize;
        int endLine = _textPageNumber * _textPageLineSize + _textWindowLineSize;

        if (endLine > splitText.Length - 1)
        {
            endLine = splitText.Length - 1;
            startLine = Mathf.Max(0, endLine - _textWindowLineSize);
        }

        var textPage = new StringBuilder();
        for (int lineIndex = startLine; lineIndex <= endLine; lineIndex++)
        {
            textPage.Append(splitText[lineIndex]);
            textPage.Append("\n");
        }
        text = textPage.ToString();

        Vector2 guiPosition = GUIUtility.ScreenToGUIPoint(screenPosition);

        var content = new GUIContent(text);
        Vector2 rectSize = _guiStyle.CalcSize(content);

        GUI.Label(new Rect(guiPosition.x - rectSize.x / 2f, Screen.height - guiPosition.y - rectSize.y, rectSize.x, rectSize.y), content, _guiStyle);
    }

    public void AddBehaviorTree(IReadOnlyNode rootBehaviorNode, string behaviorName = DefaultBehaviorTreeName)
    {
        _behaviorTrees.Add(new BehaviorTree(rootBehaviorNode, behaviorName));
    }

    public void RemoveBehaviorTree(IReadOnlyNode rootBehaviorNode)
    {
        _behaviorTrees.RemoveAll(behaviorTree => behaviorTree.RootNode == rootBehaviorNode);
    }

    /// <summary>
    /// One-liner method for automatically creating graph overlay MonoBehavior in the targeted anchor GameObject.
    /// </summary>
    public static TextGraphOverlay AddBehaviorTreeAndOverlayComponent(Transform anchorTransform, IReadOnlyNode rootBehaviorNode, string behaviorName = DefaultBehaviorTreeName, bool initiallyVisible = DefaultVisible, KeyCode toggleButton = DefaultToggleButton)
    {
        TextGraphOverlay textGraphOverlay = anchorTransform.GetComponent<TextGraphOverlay>();
        if (textGraphOverlay != null)
        {
            textGraphOverlay.AddBehaviorTree(rootBehaviorNode, behaviorName);
        }
        else
        {
            TextGraphOverlay newTextGraphOverlay = anchorTransform.gameObject.AddComponent<TextGraphOverlay>();
            newTextGraphOverlay.Visible = initiallyVisible;
            newTextGraphOverlay.ToggleButton = toggleButton;

            newTextGraphOverlay.AddBehaviorTree(rootBehaviorNode, behaviorName);
        }

        return textGraphOverlay;
    }

    /// <summary>
    /// One-liner method for removing graph overlay and the MonoBehavior associated with it when all BTs are removed.
    /// </summary>
    public static void RemoveBehaviorTreeAndOverlayComponent(Transform anchorTransform, IReadOnlyNode rootBehaviorNode)
    {
        TextGraphOverlay textGraphOverlay = anchorTransform.GetComponent<TextGraphOverlay>();
        if (textGraphOverlay != null)
        {
            textGraphOverlay.RemoveBehaviorTree(rootBehaviorNode);
            if (textGraphOverlay._behaviorTrees.Count == 0)
                Destroy(textGraphOverlay);
        }
        else
        {
            TextGraphOverlay newTextGraphOverlay = anchorTransform.gameObject.AddComponent<TextGraphOverlay>();
            newTextGraphOverlay.AddBehaviorTree(rootBehaviorNode);
        }
    }

    private class BehaviorTree
    {
        public readonly IReadOnlyNode RootNode;
        public readonly string Name;

        public BehaviorTree(IReadOnlyNode rootNode, string name)
        {
            RootNode = rootNode;
            Name = name;
        }
    }
}
