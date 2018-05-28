using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperCatch
{
    public class BallManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject ballPrefab;
        [SerializeField]
        public MotionPrefab motionPrefab;
        [SerializeField]
        private bool showCurrentPath;

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
                //Instatiate ball at ballThrowPoint which is paths[0].point_1
                GameObject ball = Instantiate(ballPrefab, motionPrefab.motionData.paths[0].point_1, Quaternion.identity);
            }
        }

        private void OnDrawGizmos()
        {
            if (motionPrefab != null)
            {
                if (showCurrentPath)
                {
                    foreach (Path path in motionPrefab.motionData.paths)
                    {
                        Physics.ProjectileVelocity(path);
                    }
                }
            }
        }
    }
}