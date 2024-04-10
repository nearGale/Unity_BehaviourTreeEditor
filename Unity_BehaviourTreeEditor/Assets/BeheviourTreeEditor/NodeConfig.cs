using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 节点细分类型
/// Selctor、Sequence仅有一个类型，不加入枚举了
/// TODO：可扩展带记忆类型的复合节点
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
    };
}
