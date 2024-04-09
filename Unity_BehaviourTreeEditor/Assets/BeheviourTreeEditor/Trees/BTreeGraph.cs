using LitJson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
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

    [ContextMenu("GetJsonString")]
    private string GetJsonString()
    {
        JsonData jsonData = new JsonData();
        var root = GetRootNode();
        root.GetJsonData(ref jsonData);


        var jsonStr = jsonData.ToJson();

        // 将中文的unicode转成能识别的GBK编码
        Regex reg = new Regex(@"(?i)\\[uU]([0-9a-f]{4})");
        jsonStr = reg.Replace(jsonStr, delegate (Match m) { return ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString(); });

        Debug.Log(jsonStr);
        return jsonStr;
    }

    [ContextMenu("WriteJson")]
    private void WriteJson()
    {
        string JsonPath = Application.dataPath + "/userInfo.json";

        var data = GetJsonString();
        WriteDataToJson(data, JsonPath);

        AssetDatabase.Refresh();
    }

    private void WriteDataToJson(string data, string jsonPath)
    {
        System.IO.File.WriteAllText(jsonPath, data);
    }
}