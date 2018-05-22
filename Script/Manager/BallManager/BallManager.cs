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
        public GameObject ballStrikePoint;
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
                ball.GetComponent<Ball>().ProjectBall(ballThrowPoint.transform.position, ballStrikePoint.transform.position, 15);
            }

            Physics.ProjectileVelocity(ballThrowPoint.transform.position, ballStrikePoint.transform.position, 15);
            Physics.ProjectileVelocity(ballStrikePoint.transform.position, ballCatchPoint.transform.position, 15);
        }
    }
}