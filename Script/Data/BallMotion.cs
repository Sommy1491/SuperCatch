using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperCatch
{
    [CreateAssetMenu(fileName = "NewScriptableObject", menuName = "ScriptableObject")]
    public class BallMotion : ScriptableObject
    {
        public Path[] paths; 
    }
}
