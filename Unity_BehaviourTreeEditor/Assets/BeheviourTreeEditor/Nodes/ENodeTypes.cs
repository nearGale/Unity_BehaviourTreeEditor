using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENodeTypes
{
    Root_Selector,
    Selctor,
    Sequence,
    // Condition Node
    ConditionFalse,
    ConditionTrue,
    // Action Node
    ActionLog,
    ActionWait,
}
