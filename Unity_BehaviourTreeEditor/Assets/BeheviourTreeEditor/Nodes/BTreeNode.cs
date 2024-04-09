using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using XNode;

[CreateNodeMenu("")] // 隐藏创建菜单显示
public class BTreeNode : Node
{
    public virtual void Shortcut()
    {
        Debug.Log(this.GetType().Name);
    }
}
