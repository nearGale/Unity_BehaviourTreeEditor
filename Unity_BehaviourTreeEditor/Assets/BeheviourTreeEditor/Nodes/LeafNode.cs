using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateNodeMenu("")] // 隐藏创建菜单显示
[NodeWidth(300)] // 节点宽度
public class LeafNode : BTreeNode
{
    [Input] public int parent;
    public ENodeType type;
    public string param;

    public override void Shortcut()
    {
        Debug.Log($"{this.GetType().Name} {type}");
    }

    public override bool GetJsonData(ref JsonData jsonData)
    {
        base.GetJsonData(ref jsonData);

        if(jsonData.ContainsKey(name)) 
        {
            Debug.LogError($"[ERR]导出失败！！有重名节点:{name}！");
            return false;
        }

        jsonData[name] = new JsonData(); // name 作为唯一key
        jsonData[name]["type"] = type.ToString();
        jsonData[name]["param"] = param;

        return true;
    }
}
