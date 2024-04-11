using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeheviourTreeEditor
{
    [NodeTint(0.3f, 0.3f, 0.8f)] // 节点颜色
    public class SequenceNode : CompositeNode
    {
        [Input] public int parent;

    }
}