using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperCatch
{
    public class BallManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject ball;
        [SerializeField]
        private GameObject ballStrikePoint;
        
        private void Awake()
        {
            
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            Vector3 ballVelocity = Physics.ProjectileVelocity(ball.transform.position, ballStrikePoint.transform.position, 30);
            Debug.DrawRay(ball.transform.position, ballVelocity, Color.red);
        }
    }
}