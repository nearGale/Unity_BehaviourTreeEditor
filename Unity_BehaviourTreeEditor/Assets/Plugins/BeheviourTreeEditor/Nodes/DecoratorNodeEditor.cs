using static UnityEngine.GraphicsBuffer;
using static XNodeEditor.NodeEditor;
using UnityEditor;
using XNodeEditor;

namespace BeheviourTreeEditor
{
    /// <summary>
    /// 节点个性化显示的【节点编辑器】
    /// </summary>
    [CustomNodeEditor(typeof(DecoratorNode))]
    public class DecoratorNodeEditor : NodeEditor
    {
        private DecoratorNode node;

        public override void OnBodyGUI()
        {
            if (node == null) node = target as DecoratorNode;

            // Update serialized object's representation
            serializedObject.Update();

            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("parent"));
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("child"));
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("type"));

            if (NodeConfig.DictNodeParams.TryGetValue(node.type, out var paramStr))
            {
                UnityEditor.EditorGUILayout.LabelField("参数格式：" + paramStr);
                NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("param"));
            }

            // Apply property modifications
            serializedObject.ApplyModifiedProperties();
        }
    }
}