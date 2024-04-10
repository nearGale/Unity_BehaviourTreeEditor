using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 装饰器节点
/// </summary>
[NodeTint(0.3f, 0.3f, 0.3f)] // 节点颜色
[NodeWidth(300)] // 节点宽度
public class DecoratorNode : BTreeNode
{
    [Input] public int parent;
    [Output] public int child;
    public ENodeType type;
    public string param;

    public override void Shortcut()
    {
        base.Shortcut();

        var childPort = GetOutputPort("child");
        var connections = childPort.GetConnections();

        if(connections.Count == 0)
            Debug.LogError($"{name} has no child!!!");

        if(connections.Count > 1)
            Debug.LogError($"{name} has more than 1 child!!!");

        (connections[0].node as BTreeNode).Shortcut();
    }

    public override bool GetJsonData(ref JsonData jsonData)
    {
        base.GetJsonData(ref jsonData);

        var childrenPort = GetOutputPort("child");
        var connections = childrenPort.GetConnections();

        if (connections.Count == 0)
            Debug.LogError($"[ERR]导出失败！！装饰器节点 {name} 没有子节点!!!");

        if (connections.Count > 1)
            Debug.LogError($"[ERR]导出失败！！装饰器节点 {name} 有超过 1 个子节点!!!");

        // 填入自身Json
        if (jsonData.ContainsKey(name))
        {
            Debug.LogError($"[ERR]导出失败！！有重名节点:{name}！");
            return false;
        }

        jsonData[name] = new JsonData(); // name 作为唯一key
        jsonData[name]["type"] = type.ToString();
        jsonData[name]["children"] = new JsonData();
        jsonData[name]["children"] = connections[0].node.name;
        jsonData[name]["param"] = param;

        // 填入子节点Json
        var succeed = (connections[0].node as BTreeNode).GetJsonData(ref jsonData);
        if (!succeed)
            return false;

        return true;
    }
}
