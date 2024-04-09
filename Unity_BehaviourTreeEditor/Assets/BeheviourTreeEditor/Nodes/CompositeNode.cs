using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

/// <summary>
/// 复合节点
/// </summary>
[CreateNodeMenu("")] // 隐藏创建菜单显示
public class CompositeNode : BTreeNode
{
    [Output] public int children;

    public override void Shortcut()
    {
        SortChildrenNodes();

        base.Shortcut();

        var bTreeGraph = graph as BTreeGraph;
        var childrenPort = GetOutputPort(bTreeGraph.PORT_CHILDREN_NAME);
        var connections = childrenPort.GetConnections();

        foreach (var connection in connections)
        {
            (connection.node as BTreeNode).Shortcut();
        }
    }

    public override bool GetJsonData(ref JsonData jsonData)
    {
        base.GetJsonData(ref jsonData);

        SortChildrenNodes();

        var bTreeGraph = graph as BTreeGraph;
        var childrenPort = GetOutputPort(bTreeGraph.PORT_CHILDREN_NAME);
        var connections = childrenPort.GetConnections();

        // 填入自身Json
        var strChildren = "";
        for (int i = 0; i < connections.Count; i++)
        {
            strChildren += connections[i].node.name;
            if (i != connections.Count - 1)
            {
                strChildren += ", ";
            }
        }

        if (jsonData.ContainsKey(name))
        {
            Debug.LogError($"[ERR]导出失败！！有重名节点:{name}！");
            return false;
        }

        jsonData[name] = new JsonData(); // name 作为唯一key
        jsonData[name]["type"] = this.GetType().Name;
        jsonData[name]["children"] = new JsonData();
        jsonData[name]["children"] = strChildren;

        // 填入子节点Json
        foreach (var connection in connections)
        {
            var succeed = (connection.node as BTreeNode).GetJsonData(ref jsonData);
            if(!succeed)
                return false;
        }

        return true;
    }

    // 根据坐标重新排子节点的顺序
    private void SortChildrenNodes()
    {
        var bTreeGraph = graph as BTreeGraph;
        var childrenPort = GetOutputPort(bTreeGraph.PORT_CHILDREN_NAME);

        var connections = childrenPort.GetConnections();
        connections.Sort((x, y) =>
        {
            return x.node.position.y.CompareTo(y.node.position.y);
        });
    }
}
