using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[NodeTint(0.9f, 0.5f, 0.2f)] // 节点颜色
public class SelectorNode : CompositeNode
{
    [Input] public int parent;
}