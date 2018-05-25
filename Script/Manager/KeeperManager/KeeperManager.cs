using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperCatch
{
    public class KeeperManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject gloves;
        private Region region;

        private void Start()
        {
            region = gloves.GetComponent<Region>();
        }

        private void Update()
        {
            if (Input.OnDrag(gloves))
            {
                Vector3 pointOnPlane = gloves.transform.position - Camera.main.transform.position;
                Vector3 worldPoint = SuperCatch.CameraManager.ScreenToWorldPoint(pointOnPlane, UnityEngine.Input.mousePosition);

                if (region.PointLocation(worldPoint) == Location.Inside)
                {
                    gloves.transform.position = worldPoint;
                }

                else if (region.PointLocation(worldPoint) == Location.LeftSide)
                {
                    gloves.transform.position = new Vector3(region.BottomLeft.x, worldPoint.y, gloves.transform.position.z);
                }

                else if (region.PointLocation(worldPoint) == Location.RightSide)
                {
                    gloves.transform.position = new Vector3(region.TopRight.x, worldPoint.y, gloves.transform.position.z);
                }

                else if (region.PointLocation(worldPoint) == Location.DownSide)
                {
                    gloves.transform.position = new Vector3(worldPoint.x, region.BottomRight.y, gloves.transform.position.z);
                }

                else if (region.PointLocation(worldPoint) == Location.UpSide)
                {
                    gloves.transform.position = new Vector3(worldPoint.x, region.TopRight.y, gloves.transform.position.z);
                }

                else if (region.PointLocation(worldPoint) == Location.OutSide)
                {

                }

            }
        }
    }
}

