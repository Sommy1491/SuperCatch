using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperCatch
{
    [CreateAssetMenu(fileName = "NewScriptableObject", menuName = "ScriptableObject/MotionPrefab", order = 2)]
    public class MotionPrefab : ScriptableObject
    {
        public Path[] paths = new Path[3];
    }
}