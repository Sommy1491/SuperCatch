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
        [SerializeField]
        public BallMotion ballMotion;
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
            }

            
        }

        private void OnDrawGizmos()
        {
            ballMotion.paths[0].point_1 = ballThrowPoint.transform.position;
            ballMotion.paths[0].point_2 = ballPitchPoint.transform.position;

            ballMotion.paths[1].point_1 = ballPitchPoint.transform.position;
            ballMotion.paths[1].point_2 = ballBatPoint.transform.position;

            ballMotion.paths[2].point_1 = ballBatPoint.transform.position;
            ballMotion.paths[2].point_2 = ballCatchPoint.transform.position;

            CreatePath();
        }

        private void CreatePath()
        {
            foreach(Path path in ballMotion.paths)
            {
                Physics.ProjectileVelocity(path);
            }
        }
    }
}