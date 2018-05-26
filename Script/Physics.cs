using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperCatch
{
    public class Physics
    {
        private static float g = 9.81f; //*******GRAVITY***********//  

        public static Vector3 ProjectileVelocity(Path path)
        {
            //Assign source point and target point and Angle of Projection
            Vector3 sourcePosition = path.point_1;
            Vector3 targetPosition = path.point_2;
            float angleOfProjection = path.angle;

            //Took the sourcePosition to origin
            Vector3 sourceOffSet = sourcePosition;
            sourcePosition -= sourceOffSet;
            targetPosition -= sourceOffSet;

            //Range Direction
            Vector3 R_Dir = (targetPosition - sourcePosition);
            //Range Magnitude
            float R = R_Dir.magnitude;
            //Range X Component
            Vector3 R_X = new Vector3(R_Dir.x, 0, 0);
            //Range Y Component
            Vector3 R_Y = new Vector3(0, R_Dir.y, 0);
            //Range Z Component
            Vector3 R_Z = new Vector3(0, 0, R_Dir.z);
            //Range XZ Component
            Vector3 R_XZ = new Vector3(R_Dir.x, 0, R_Dir.z);

            //Rotate XZ Y Plane(Plane of Projectile motion) towards arbitary XY Plane
            //angle between xz axis and x axis;
            float beta = Vector3.SignedAngle(Vector3.right, R_XZ.normalized, Vector3.up); //According to left hand rule clockwise is positive
            R_Dir = Quaternion.Euler(0, -beta, 0) * R_Dir;

            //After this stage calculation will made assuming the projection plane to XY;

            //angle of inclination w.r.t horizontal
            float alpha = Vector3.SignedAngle(Vector3.right, R_Dir, Vector3.forward);

            //angle of project velocity w.r.t horizontal
            float Theta = alpha + angleOfProjection;

            //Magnitude of Velocity;
            float u = Mathf.Sqrt((R * g * Mathf.Cos(alpha * Mathf.Deg2Rad) * Mathf.Cos(alpha * Mathf.Deg2Rad)) /
                        (float)(Mathf.Sin((2 * Theta - alpha) * Mathf.Deg2Rad) - Mathf.Sin(alpha * Mathf.Deg2Rad)));

            //Velocity X Component
            Vector3 uX = u * Mathf.Cos(Theta * Mathf.Deg2Rad) * Vector3.right;
            //Velocity Y Component
            Vector3 uY = u * Mathf.Sin(Theta * Mathf.Deg2Rad) * Vector3.up;

            Vector3 u_Dir = uX + uY;

            /*****************************************************************************
            *******************************Show Trajectory Start********************************
            ******************************************************************************/
            float step = 0.5f;

            for (float x = 0; x < R_XZ.magnitude; x += step)
            {
                float y = (x * Mathf.Tan(Theta * Mathf.Deg2Rad)) -
                    ((g * x * x) /
                    (2 * u * u * Mathf.Cos(Theta * Mathf.Deg2Rad) * Mathf.Cos(Theta * Mathf.Deg2Rad)));

                float yPlusStep = ((x + step) * Mathf.Tan(Theta * Mathf.Deg2Rad)) - ((g * (x + step) * (x + step)) /
                    (2 * u * u * Mathf.Cos(Theta * Mathf.Deg2Rad) * Mathf.Cos(Theta * Mathf.Deg2Rad)));

                //Add sourceOff to Position to bring them back to original position
                Vector3 PosVector = new Vector3(x, y, 0);
                Vector3 PosVectorPlusStep = new Vector3(x + step, yPlusStep, 0);

                PosVector = Quaternion.Euler(0, beta, 0) * PosVector;
                PosVectorPlusStep = Quaternion.Euler(0, beta, 0) * PosVectorPlusStep;

                PosVector += sourceOffSet;
                PosVectorPlusStep += sourceOffSet;

                Debug.DrawLine(PosVector, PosVectorPlusStep, Color.magenta);
            }

            /*****************************************************************************
            *******************************Show Trajectory End********************************
            ******************************************************************************/

            //Upto this step projection velocity is calculate in XY Plane
            //Now time to Project everything in XZ Y Plane

            R_Dir = Quaternion.Euler(0, beta, 0) * R_Dir;
            u_Dir = Quaternion.Euler(0, beta, 0) * u_Dir;

            return u_Dir;
        }

        public static Vector3 getTrajectoryPoint(Path path, float x) //here point is a coordinate on x axis defining the trajectory on XY Plane
        {
            //Assign source point and target point and Angle of Projection
            Vector3 sourcePosition = path.point_1;
            Vector3 targetPosition = path.point_2;
            float angleOfProjection = path.angle;

            //Took the sourcePosition to origin
            Vector3 sourceOffSet = sourcePosition;
            sourcePosition -= sourceOffSet;
            targetPosition -= sourceOffSet;

            //Range Direction
            Vector3 R_Dir = (targetPosition - sourcePosition);
            //Range Magnitude
            float R = R_Dir.magnitude;
            //Range X Component
            Vector3 R_X = new Vector3(R_Dir.x, 0, 0);
            //Range Y Component
            Vector3 R_Y = new Vector3(0, R_Dir.y, 0);
            //Range Z Component
            Vector3 R_Z = new Vector3(0, 0, R_Dir.z);
            //Range XZ Component
            Vector3 R_XZ = new Vector3(R_Dir.x, 0, R_Dir.z);

            //Rotate XZ Y Plane(Plane of Projectile motion) towards arbitary XY Plane
            //angle between xz axis and x axis;
            float beta = Vector3.SignedAngle(Vector3.right, R_XZ.normalized, Vector3.up); //According to left hand rule clockwise is positive
            R_Dir = Quaternion.Euler(0, -beta, 0) * R_Dir;

            //After this stage calculation will made assuming the projection plane to XY;

            //angle of inclination w.r.t horizontal
            float alpha = Vector3.SignedAngle(Vector3.right, R_Dir, Vector3.forward);

            //angle of project velocity w.r.t horizontal
            float Theta = alpha + angleOfProjection;

            //Magnitude of Velocity;
            float u = Mathf.Sqrt((R * g * Mathf.Cos(alpha * Mathf.Deg2Rad) * Mathf.Cos(alpha * Mathf.Deg2Rad)) /
                        (float)(Mathf.Sin((2 * Theta - alpha) * Mathf.Deg2Rad) - Mathf.Sin(alpha * Mathf.Deg2Rad)));

            //Velocity X Component
            Vector3 uX = u * Mathf.Cos(Theta * Mathf.Deg2Rad) * Vector3.right;
            //Velocity Y Component
            Vector3 uY = u * Mathf.Sin(Theta * Mathf.Deg2Rad) * Vector3.up;

            Vector3 u_Dir = uX + uY;

            //Equation of Trajectory
            float y = (x * Mathf.Tan(Theta * Mathf.Deg2Rad)) -
                    ((g * x * x) /
                    (2 * u * u * Mathf.Cos(Theta * Mathf.Deg2Rad) * Mathf.Cos(Theta * Mathf.Deg2Rad)));

            //Add sourceOff to Position to bring them back to original position
            Vector3 PosVector = new Vector3(x, y, 0);

            PosVector = Quaternion.Euler(0, beta, 0) * PosVector;

            PosVector += sourceOffSet;

            return PosVector;
        }

        public static float getTrajectoryRange(Path path)
        {
            //Assign source point and target point and Angle of Projection
            Vector3 sourcePosition = path.point_1;
            Vector3 targetPosition = path.point_2;
            float angleOfProjection = path.angle;

            //Took the sourcePosition to origin
            Vector3 sourceOffSet = sourcePosition;
            sourcePosition -= sourceOffSet;
            targetPosition -= sourceOffSet;

            //Range Direction
            Vector3 R_Dir = (targetPosition - sourcePosition);
            //Range Magnitude
            float R = R_Dir.magnitude;
            //Range X Component
            Vector3 R_X = new Vector3(R_Dir.x, 0, 0);
            //Range Y Component
            Vector3 R_Y = new Vector3(0, R_Dir.y, 0);
            //Range Z Component
            Vector3 R_Z = new Vector3(0, 0, R_Dir.z);
            //Range XZ Component
            Vector3 R_XZ = new Vector3(R_Dir.x, 0, R_Dir.z);

            return R_XZ.magnitude;
        }
    }
}

