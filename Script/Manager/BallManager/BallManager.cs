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
        public MotionSampleSet motionSampleSet;
        [SerializeField]
        public int currentMotionIndex;

        private void Awake()
        {
            
        }

        private void Start()
        {
            
        }
    }
}