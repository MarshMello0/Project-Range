using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDebugScript : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(-Vector3.up * 100000);
        StartCoroutine("DestroyTimer");
    }

    void OnCollisionEnter(Collision hit)
    {
        if(hit.collider.name != "Bullet(Clone)")
        {
            Destroy(gameObject);
        }
        
    }
    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
