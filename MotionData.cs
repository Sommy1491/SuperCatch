using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperCatch
{
    public class MotionData : MonoBehaviour
    {
        public MotionPrefab motionPrefab;
        [SerializeField]
        private GameObject ballThrowPoint;
        [SerializeField]
        public GameObject ballPitchPoint;
        [SerializeField]
        public GameObject ballBatPoint;
        [SerializeField]
        public GameObject ballCatchPoint;
        [SerializeField]
        private Path[] paths = new Path[3];

        private void OnDrawGizmos()
        {
            paths[0].point_1 = ballThrowPoint.transform.position;
            paths[0].point_2 = ballPitchPoint.transform.position;

            paths[1].point_1 = ballPitchPoint.transform.position;
            paths[1].point_2 = ballBatPoint.transform.position;

            paths[2].point_1 = ballBatPoint.transform.position;
            paths[2].point_2 = ballCatchPoint.transform.position;

            CreatePath();
            FetchMotionData();
        }

        private void CreatePath()
        {
            foreach(Path path in paths)
            {
                Physics.ProjectileVelocity(path);
            }
        }

        private void FetchMotionData()
        {
            motionPrefab.paths = this.paths;
        }
    }
}