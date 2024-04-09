using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateNodeMenu("")] // 隐藏创建菜单显示
[NodeWidth(300)] // 节点宽度
public class LeafNode : BTreeNode
{
    [Input] public int parent;
    public ENodeTypes type;
    public string param;

    public override void Shortcut()
    {
        Debug.Log($"{this.GetType().Name} {type}");
    }

    public override void GetJsonData(ref JsonData jsonData)
    {
        base.GetJsonData(ref jsonData);

        jsonData[name] = new JsonData(); // name 作为唯一key
        jsonData[name]["type"] = type.ToString();
        jsonData[name]["param"] = param;
    }
}
