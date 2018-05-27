using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperCatch
{
    [CreateAssetMenu(fileName = "NewScriptableObject", menuName = "ScriptableObject/MotionSampleSet", order = 1)]
    public class MotionSampleSet : ScriptableObject
    {
        public int currentMotionIndex;
        public MotionPrefab[] motionPrefab;
    }
}

