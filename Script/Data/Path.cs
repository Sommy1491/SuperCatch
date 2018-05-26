using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperCatch
{
    [System.Serializable]
    public class Path
    {
        public Vector3 point_1;//source point
        public Vector3 point_2;//destination point
        public float angle;//Angle of Projection
        public float pathSpeed;
        public bool isTruePhysics = false;
    }
}

