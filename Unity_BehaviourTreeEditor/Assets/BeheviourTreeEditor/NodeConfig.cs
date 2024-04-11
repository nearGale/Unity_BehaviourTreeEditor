using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

namespace BeheviourTreeEditor
{
    /// <summary>
    /// 节点细分类型
    /// Selctor、Sequence仅有一个类型，不加入枚举了
    /// </summary>
    public enum ENodeType
    {
        // Condition Node
        ConditionFalse,
        ConditionTrue,
        // Action Node
        ActionLog,
        ActionWait,
        // Decorator
        DecoratorInvert,
        DecoratorRepeat,
    }

    public static class NodeConfig
    {
        /// <summary>
        /// 配置节点参数，多个参数由英文逗号分割","
        /// </summary>
        public static Dictionary<ENodeType, string> DictNodeParams = new Dictionary<ENodeType, string>()
    {
        {ENodeType.ActionWait, "seconds(float)" },
        {ENodeType.ActionLog, "content(string)" },
        {ENodeType.DecoratorRepeat, "times(int)" },
    };

        public static string OutputPath = $"{Application.dataPath}/";
        //public static string OutputPath = "D:/BTrees/"; // 需要存在这个路径
    }
}