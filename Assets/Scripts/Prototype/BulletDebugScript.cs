using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDebugScript : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.up * 100000);
    }

    void OnCollisionEnter(Collision hit)
    {
        print(hit.collider.name + ". at " + transform.position);
        if(hit.collider.name != "Bullet(Clone)")
        {
            Destroy(gameObject);
        }
        
    }
}
