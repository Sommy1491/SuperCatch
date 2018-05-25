using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperCatch
{
    public enum Location
    {
        Inside,
        LeftSide,
        RightSide,
        UpSide,
        DownSide,
        OutSide
    }

    public class Region : MonoBehaviour
    {
        [SerializeField]
        private float x, y;
        [SerializeField]
        private float width = Screen.width, height = Screen.height;

        private Vector3 bottomLeft, bottomRight, topLeft, topRight;
        public Vector3 BottomLeft
        {
            get { return bottomLeft; }
        }

        public Vector3 BottomRight
        {
            get { return bottomRight; }
        }

        public Vector3 TopLeft
        {
            get { return topLeft; }
        }

        public Vector3 TopRight
        {
            get { return topRight; }
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            Debug.DrawLine(bottomLeft, bottomRight, Color.red);
            Debug.DrawLine(topLeft, topRight, Color.red);
            Debug.DrawLine(bottomLeft, topLeft, Color.green);
            Debug.DrawLine(bottomRight, topRight, Color.green);

            CalculateBounds();
        }

        public void CalculateBounds()
        {
            //...........Clamp the width and height upto Screen Resolution...............//
            width = Mathf.Clamp(width, 0, Screen.width);
            height = Mathf.Clamp(height, 0, Screen.height);

            Vector3 pointOnPlane = this.transform.position - UnityEngine.Camera.main.transform.position;

            bottomLeft = CameraManager.ScreenToWorldPoint(pointOnPlane, new Vector3(x, y, 0));
            bottomRight = CameraManager.ScreenToWorldPoint(pointOnPlane, new Vector3(width, y, 0));
            topLeft = CameraManager.ScreenToWorldPoint(pointOnPlane, new Vector3(x, height, 0));
            topRight = CameraManager.ScreenToWorldPoint(pointOnPlane, new Vector3(width, height, 0));
        }

        public Location PointLocation(Vector3 point)
        {
            Ray verticalLeft = new Ray(bottomLeft, (topLeft - bottomLeft));
            Ray horizontalDown = new Ray(bottomLeft, (bottomRight - bottomLeft));

            Ray verticalRight = new Ray(topRight, (topRight - bottomRight));
            Ray horizontalUp = new Ray(topRight, (topLeft - topRight));

            float distanceLeft = Vector3.Cross(verticalLeft.direction, point - verticalLeft.origin).magnitude;
            float distanceRight = Vector3.Cross(verticalRight.direction, point - verticalRight.origin).magnitude;
            float distanceTop = Vector3.Cross(horizontalUp.direction, point - horizontalUp.origin).magnitude;
            float distanceBottom = Vector3.Cross(horizontalDown.direction, point - horizontalDown.origin).magnitude;

            //.............Point is Inside the Region.................//
            if (Mathf.Approximately((distanceLeft + distanceRight), (bottomRight - bottomLeft).magnitude) &&
                Mathf.Approximately((distanceBottom + distanceTop), (topLeft - bottomLeft).magnitude))
            {
                return Location.Inside;
            }

            //.............Point is UpSide or DownSide of The Region.................//
            else if (Mathf.Approximately((distanceLeft + distanceRight), (bottomRight - bottomLeft).magnitude) &&
                !Mathf.Approximately((distanceBottom + distanceTop), (topLeft - bottomLeft).magnitude))
            {
                if (distanceTop < distanceBottom)
                    return Location.UpSide;
                else
                    return Location.DownSide;
            }

            //.............Point is LeftSide or RightSide of The Region.................//
            else if (!Mathf.Approximately((distanceLeft + distanceRight), (bottomRight - bottomLeft).magnitude) &&
                Mathf.Approximately((distanceBottom + distanceTop), (topLeft - bottomLeft).magnitude))
            {
                if (distanceLeft < distanceRight)
                    return Location.LeftSide;

                else 
                    return Location.RightSide;
            }

            //.................Point is Completely outside of the region......................//
            else
                return Location.OutSide;
        }
    }
}