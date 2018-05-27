using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperCatch
{
    public class Ball : MonoBehaviour
    {
        public float speed;
        public float pathRange;
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
            if (currentPathIndex < ballManager.motionSampleSet.motionPrefab[ballManager.currentMotionIndex].paths.Length)
            {
                amtToMove += speed * Time.deltaTime;
                if (amtToMove <= pathRange)
                    this.transform.position = Physics.getTrajectoryPoint(ballManager.motionSampleSet.motionPrefab[ballManager.currentMotionIndex].paths[currentPathIndex], amtToMove);

                else
                {
                    currentPathIndex++;
                    if (currentPathIndex < ballManager.motionSampleSet.motionPrefab[ballManager.currentMotionIndex].paths.Length)
                        ResetPathValue();
                }
            }
        }

        private void ResetPathValue()
        {            
            amtToMove = 0;

            //.........Apply False Physics to follow follow the Trajectory(Speed is given by user)
            if (!ballManager.motionSampleSet.motionPrefab[ballManager.currentMotionIndex].paths[currentPathIndex].isTruePhysics)
                speed = ballManager.motionSampleSet.motionPrefab[ballManager.currentMotionIndex].paths[currentPathIndex].pathSpeed;

            //........Apply True Physics to follow the Trajectory(Speed is calculated by true equation)
            else
                speed = Physics.ProjectileVelocity(ballManager.motionSampleSet.motionPrefab[currentPathIndex].paths[currentPathIndex]).magnitude;

            pathRange = Physics.getTrajectoryRange(ballManager.motionSampleSet.motionPrefab[ballManager.currentMotionIndex].paths[currentPathIndex]);
        }
    }
}

