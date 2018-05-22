using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperCatch
{
    public class Ball : MonoBehaviour
    {
        private BallManager ballManager;
        private float angle;
        private bool isStrike = false;

        private void Start()
        {
            ballManager = Manager.getInstance().ballManager;
        }

        public void ProjectBall(Vector3 from, Vector3 to, float angle)
        {
            this.angle = angle;
            this.GetComponent<Rigidbody>().velocity = Physics.ProjectileVelocity(from, to, angle);
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (!isStrike)
            {
                Debug.Log("Enter");
                isStrike = true;
                this.GetComponent<Rigidbody>().velocity = Physics.ProjectileVelocity(ballManager.ballStrikePoint.transform.position, ballManager.ballCatchPoint.transform.position, angle);
            }
        }
    }
}

