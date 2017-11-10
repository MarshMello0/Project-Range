using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[AddComponentMenu("Camera-Control/Smooth Mouse Look")]
public class CameraMovement : MonoBehaviour
{
    [Header("Players Camera")]
    public Camera firstPersonCamera;
    [Header("Settings")]
    [Header("Camera Zoom Settings")]
    public int currentFOV;
    public float zoomSmoothing;
    [Header("Camera Rotation Settings")]
    public float sensitivity = 5;
    public float smoothing = 2;
    [Header("Max Look up and down")]
    public float yMaxAngle;
    public float yMinAngle;
    Vector2 mouseLook;
    Vector2 smoothV;
    public Transform playerTRA;
    private void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1 / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1 / smoothing);
        mouseLook += smoothV;

        mouseLook.y = Mathf.Clamp(mouseLook.y, yMinAngle, yMaxAngle);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        playerTRA.localRotation = Quaternion.AngleAxis(mouseLook.x, playerTRA.up);

        StartCoroutine("Zoom");
       
    }

    IEnumerator Zoom()
    {
        if (Input.GetMouseButtonDown(1))
        {
            for (int i = currentFOV;i > 20;i--)
            {
                firstPersonCamera.fieldOfView = i;
                yield return new WaitForSeconds(0.0000000000001f);
            }
            
        }
        if (Input.GetMouseButtonUp(1))
        {
            for (int i = 20; i < currentFOV; i++)
            {
                firstPersonCamera.fieldOfView = i;
                yield return new WaitForSeconds(0.0000000000001f);
            }
        }
    }
}