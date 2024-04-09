using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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

    public virtual void GetJsonData(ref JsonData jsonData) { }
}
