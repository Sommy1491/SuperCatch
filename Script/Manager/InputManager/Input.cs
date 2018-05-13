using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperCatch
{
    public class Input
    {
        public static bool OnTap(GameObject gameObject)
        {
            if(UnityEngine.Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);

                if(Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == gameObject)
                        return true;
                }
            }

            return false;
        }
    }
}

