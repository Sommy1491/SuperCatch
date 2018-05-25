using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperCatch
{
    public class BallManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject ballThrowPoint;
        [SerializeField]
        public GameObject ballPitchPoint;
        [SerializeField]
        public GameObject ballBatPoint;
        [SerializeField]
        public GameObject ballCatchPoint;
        [SerializeField]
        private GameObject ballPrefab;

        private void Awake()
        {
            
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            if(UnityEngine.Input.GetKeyUp(KeyCode.Space))
            {
                GameObject ball = Instantiate(ballPrefab, ballThrowPoint.transform.position, Quaternion.identity);
                ball.GetComponent<Ball>().ProjectBall(ballThrowPoint.transform.position, ballPitchPoint.transform.position, ballThrowPoint.GetComponent<AngleOfProjection>().projectionAngle);
            }

            
        }

        private void OnDrawGizmos()
        {
            Physics.ProjectileVelocity(ballThrowPoint.transform.position, ballPitchPoint.transform.position, ballThrowPoint.GetComponent<AngleOfProjection>().projectionAngle);
            Physics.ProjectileVelocity(ballPitchPoint.transform.position, ballBatPoint.transform.position, ballPitchPoint.GetComponent<AngleOfProjection>().projectionAngle);
            Physics.ProjectileVelocity(ballBatPoint.transform.position, ballCatchPoint.transform.position, ballBatPoint.GetComponent<AngleOfProjection>().projectionAngle);
        }
    }
}