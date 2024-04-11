using LitJson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;
using XNode;

namespace BeheviourTreeEditor
{
    [CreateAssetMenu]
    public class BTreeGraph : NodeGraph
    {
        public string ROOT_NODE_NAME = "Root";
        public string PORT_PARENT_NAME = "parent";
        public string PORT_CHILDREN_NAME = "children";

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
            bool succeed = root.GetJsonData(ref jsonData);

            if (!succeed)
            {
                return null;
            }

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
            string JsonPath = NodeConfig.OutputPath + $"{name}.json";

            var data = GetJsonString();
            if (string.IsNullOrEmpty(data))
            {
                Debug.LogError("行为树json导出失败！！！");
                return;
            }

            WriteDataToJson(data, JsonPath);

            AssetDatabase.Refresh();
        }

        private void WriteDataToJson(string data, string jsonPath)
        {
            System.IO.File.WriteAllText(jsonPath, data);
            Debug.Log($"导出成功！行为树json路径：{jsonPath}");
        }
    }
}