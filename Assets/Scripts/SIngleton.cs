using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton
{
    public class SIngleton<T> : MonoBehaviour where T : MonoBehaviour
    {

        public static T Instance;


        private void Awake()
        {
            if (Instance = null)
                Instance = GetComponent<T>();
            else
                Destroy(gameObject);
        }
    }
}
