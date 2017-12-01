using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TargetController : MonoBehaviour
{
    [Header("This must be attacted to the targets gameobject")]
    [SerializeField]
    [Tooltip("This is the distance that the target will move before it pops up")]
    private float targetsMoveDistanceBefore;
    [SerializeField]
    [Tooltip("This is the distance that the target will move after it pops up")]
    private float targetsMoveDistanceAfter;
    [SerializeField]
    [Tooltip("This is the delay for when the targets starts to move")]
    private float targetsDelayBefore;
    [SerializeField]
    [Tooltip("This is the delay when it pops up, for it to start moving in seconds")]
    private float targetsDelayAfter;
    [SerializeField]
    [Tooltip("The time which the target will stay up")]
    private float targetsHideTimel;
    [SerializeField]
    [Tooltip("This is which axis is will move along out of x and z")]
    private bool moveOnX;

    //Runs when item is selected
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(255, 0, 0);
        if (moveOnX)
        {
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + targetsMoveDistanceBefore + targetsMoveDistanceAfter,transform.position.y,transform.position.z));
            Gizmos.color = new Color(255, 255, 0);
            Gizmos.DrawLine(new Vector3(transform.position.x + targetsMoveDistanceBefore,transform.position.y,transform.position.z), new Vector3(transform.position.x + targetsMoveDistanceBefore + targetsMoveDistanceAfter, transform.position.y, transform.position.z));
        }
        else
        {
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + targetsMoveDistanceBefore + targetsMoveDistanceAfter));
            Gizmos.color = new Color(255, 255, 0);
            Gizmos.DrawLine(new Vector3(transform.position.x, transform.position.y, transform.position.z + targetsMoveDistanceBefore), new Vector3(transform.position.x, transform.position.y, transform.position.z + targetsMoveDistanceBefore + targetsMoveDistanceAfter));
        }
        
    }
}
