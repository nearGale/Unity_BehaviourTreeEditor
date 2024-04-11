using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeheviourTreeEditor
{
    [NodeTint(0.8f, 0.3f, 0f)] // 节点颜色
    public class RootNode : CompositeNode
    {
        // 要求全场只有一个NodeRoot
        // 是特殊的Selector（没有入口）

    }
}