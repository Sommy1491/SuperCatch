using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperCatch
{
    public class Gloves : MonoBehaviour
    {
        private BallManager ballManager;
        public Animator catchAnimator;

        private void Start()
        {
            ballManager = Manager.getInstance().ballManager;
        }

        private void OnTriggerEnter(Collider collider)
        {
            if(collider.gameObject == ballManager.ballRef)
            {
                catchAnimator.SetTrigger("PlayAnim");
                Destroy(collider.gameObject);
            }
        }
    }
}
