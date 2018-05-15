using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//..................A Singleton class to Manage All Managers..............................//

namespace SuperCatch
{
    public class Manager : MonoBehaviour
    {
        private static Manager instance;

        public InputManager inputManager;
        public KeeperManager keeperManager;
        public BallManager ballManager;

        private void Awake()
        {
            if (instance == null)
                instance = this;
        }

        public static Manager getInstance()
        {
            return instance;
        }
    }
}