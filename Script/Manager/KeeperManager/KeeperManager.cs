using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperCatch
{
    public class KeeperManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject gloves;

        private void Update()
        {
            if(Input.OnDrag(gloves))
            {
                var mousePos = UnityEngine.Input.mousePosition;
                mousePos.z = 10;
                gloves.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
            }
        }
    }
}

