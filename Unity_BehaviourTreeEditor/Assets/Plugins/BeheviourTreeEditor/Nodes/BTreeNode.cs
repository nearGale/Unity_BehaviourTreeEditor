using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using XNode;

namespace BeheviourTreeEditor
{
    [CreateNodeMenu("")] // 隐藏创建菜单显示
    public class BTreeNode : Node
    {
        public virtual void Shortcut()
        {
            Debug.Log(this.GetType().Name);
        }

        public virtual bool GetJsonData(ref JsonData jsonData) { return false; }
    }
}