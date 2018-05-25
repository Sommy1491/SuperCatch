using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperCatch
{
    public class Ball : MonoBehaviour
    {
        private BallManager ballManager;
        private bool isStrike = false;

        private void Start()
        {
            ballManager = Manager.getInstance().ballManager;
        }

        public void ProjectBall(Vector3 from, Vector3 to, float angle)
        {
            this.GetComponent<Rigidbody>().velocity = Physics.ProjectileVelocity(from, to, angle);
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (!isStrike)
            {
                if (collider.gameObject.name.Equals("Pitch"))
                {
                    isStrike = true;
                    this.GetComponent<Rigidbody>().velocity = Physics.ProjectileVelocity(ballManager.ballPitchPoint.transform.position, ballManager.ballCatchPoint.transform.position, ballManager.ballPitchPoint.GetComponent<AngleOfProjection>().projectionAngle);
                }
            }
        }
    }
}

