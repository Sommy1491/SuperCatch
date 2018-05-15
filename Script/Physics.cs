using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperCatch
{
    public class Physics
    {
        public static Vector3 ProjectileVelocity(Vector3 sourcePosition, Vector3 targetPosition, float angleOfProjection)
        {
            Vector3 horizontalRangeDirection = (targetPosition - sourcePosition);
            float horizontalRangeMagnitude = horizontalRangeDirection.magnitude;



            return horizontalRangeDirection;
        }
    }
}

