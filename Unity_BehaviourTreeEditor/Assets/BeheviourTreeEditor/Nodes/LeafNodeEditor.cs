using static UnityEngine.GraphicsBuffer;
using static XNodeEditor.NodeEditor;
using UnityEditor;
using XNodeEditor;

/// <summary>
/// 节点个性化显示的【节点编辑器】
/// </summary>
[CustomNodeEditor(typeof(LeafNode))]
public class LeafNodeEditor : NodeEditor
{
    private LeafNode node;

    public override void OnBodyGUI()
    {
        if (node == null) node = target as LeafNode;

        // Update serialized object's representation
        serializedObject.Update();

        NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("parent"));
        NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("type"));

        var bTreeGraph = node.graph as BTreeGraph;
        if (bTreeGraph.DictNodeParams.TryGetValue(node.type, out var paramStr))
        {
            UnityEditor.EditorGUILayout.LabelField("参数格式：" + paramStr);
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("param"));
        }

        // Apply property modifications
        serializedObject.ApplyModifiedProperties();
    }
}