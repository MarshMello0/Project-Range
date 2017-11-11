using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("DDOL")]
public class DDOL : MonoBehaviour {
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
