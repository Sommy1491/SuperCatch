using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperCatch
{
    [CreateAssetMenu(fileName = "NewScriptableObject", menuName = "ScriptableObject/MotionData", order = 2)]
    public class MotionData : ScriptableObject
    {
        public Path[] paths = new Path[3];
    }
}