using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperCatch
{
    public class Ball : MonoBehaviour
    {
        private float pathSpeed;
        private float pathRange;
        private float amtToMove;
        private BallManager ballManager;
        private int currentPathIndex = 0;

        private void Start()
        {
            ballManager = Manager.getInstance().ballManager;
            ResetPathValue();
        }

        private void Update()
        {
            if (currentPathIndex < ballManager.motionPrefab.motionData.paths.Length)
            {
                amtToMove += pathSpeed * Time.deltaTime;
                if (amtToMove <= pathRange)
                    this.transform.position = Physics.getTrajectoryPoint(ballManager.motionPrefab.motionData.paths[currentPathIndex], amtToMove);

                else
                {
                    currentPathIndex++;
                    if (currentPathIndex < ballManager.motionPrefab.motionData.paths.Length)
                        ResetPathValue();
                }
            }
        }

        private void ResetPathValue()
        {            
            amtToMove = 0;

            //.........Apply False Physics to follow follow the Trajectory(Speed is given by user)
            if (!ballManager.motionPrefab.motionData.paths[currentPathIndex].isTruePhysics)
                pathSpeed = ballManager.motionPrefab.motionData.paths[currentPathIndex].pathSpeed;

            //........Apply True Physics to follow the Trajectory(Speed is calculated by true equation)
            else
                pathSpeed = Physics.ProjectileVelocity(ballManager.motionPrefab.motionData.paths[currentPathIndex]).magnitude;

            pathRange = Physics.getTrajectoryRange(ballManager.motionPrefab.motionData.paths[currentPathIndex]);
        }
    }
}

