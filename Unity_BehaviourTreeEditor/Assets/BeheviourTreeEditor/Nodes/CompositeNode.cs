using System.Collections;
using System.Collections.Generic;
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
        var bTreeGraph = graph as BTreeGraph;
        var childrenPort = GetOutputPort(bTreeGraph.PORT_CHILDREN_NAME);

        var connections = childrenPort.GetConnections();
        connections.Sort((x, y) =>
        {
            return x.node.position.y.CompareTo(y.node.position.y);
        });

        base.Shortcut();

        foreach (var connection in connections)
        {
            (connection.node as BTreeNode).Shortcut();
        }
    }
}
