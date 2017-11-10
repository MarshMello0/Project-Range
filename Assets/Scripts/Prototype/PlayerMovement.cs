using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("Player Scripts/Movement")]
public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]
    public float movementSpeed;
    public float jumpHeight;
    public KeyCode forward, backwards, left, right, jump;
    [Header("Scripts/Objects")]
    public Rigidbody playerRB;
    public Transform playerTra;
    private void Update()
    {
        if (Input.GetKey(forward))
        {
            playerRB.AddRelativeForce(Vector3.forward);
            print(Vector3.forward);
        }
    }
}
