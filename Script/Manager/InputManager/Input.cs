using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperCatch
{
    public class Input
    {
        private static bool dragFlag = false;

        public static bool OnTap(GameObject gameObject)
        {
            if(UnityEngine.Input.GetMouseButtonDown(0))
            {
                UnityEngine.RaycastHit hit;
                UnityEngine.Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);

                if(UnityEngine.Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == gameObject)
                        return true;
                }
            }

            return false;
        }

        public static bool OnTapRelease(GameObject gameObject)
        {
            if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                UnityEngine.RaycastHit hit;
                UnityEngine.Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);

                if (UnityEngine.Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == gameObject)
                        return true;
                }
            }

            return false;
        }

        public static bool OnDrag(GameObject gameObject)
        {
            if(Input.OnTap(gameObject))
                dragFlag = true;

            else if(Input.OnTapRelease(gameObject) || UnityEngine.Input.GetMouseButtonUp(0))
                dragFlag = false;

            return dragFlag;
        }
    }
}

