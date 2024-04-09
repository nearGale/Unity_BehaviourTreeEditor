using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using XNode;

[CreateAssetMenu]
public class BTreeGraph : NodeGraph 
{
    public string ROOT_NODE_NAME = "Root";
    public string PORT_PARENT_NAME = "parent";
    public string PORT_CHILDREN_NAME = "children";

    public Dictionary<ENodeTypes, string> DictNodeParams = new Dictionary<ENodeTypes, string>()
    {
        {ENodeTypes.ActionWait, "seconds(float)" },
        {ENodeTypes.ActionLog, "content(string),content(string)" },
    };

    /// <summary>
    /// 在节点编辑器中，右键菜单增加功能
    /// </summary>
    [ContextMenu("Do Something")]
    void DoSomething()
    {
        Debug.Log("Perform operation");
    }

    private BTreeNode GetRootNode()
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            // 要求全场只有一个NodeRoot
            if (nodes[i] is RootNode) return nodes[i] as BTreeNode;
        }
        return null;
    }


    [ContextMenu("Shortcut")]
    private void Shortcut()
    {
        var root = GetRootNode();
        Debug.Log(root.name);

        root.Shortcut();
    }
}