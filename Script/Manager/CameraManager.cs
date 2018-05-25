using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperCatch
{
    public class CameraManager
    {
        public static Vector3 ScreenToWorldPoint(Vector3 pointOnPlane, Vector3 screenPoint)
        {
            Vector3 projectionVector = Vector3.Project(pointOnPlane, UnityEngine.Camera.main.transform.forward);
            screenPoint.z = projectionVector.magnitude;

            return UnityEngine.Camera.main.ScreenToWorldPoint(screenPoint);
        }
    }
}



