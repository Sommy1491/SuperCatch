﻿using System.Collections;
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
            if(Input.OnTap(gloves))
            {
                print("gloves");
            }
        }
    }
}
