using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    /* What I want the script to do
     Have voids for each pop up and drop down
     detect when bullet hits
     */

    #region Variables

    [Header("Settings")] 
    [Tooltip("This is the order which this target will pop up in")] [Range(0,99)] public int target_Number;
    [Header("Scripts")]
    [Tooltip("This is the Challenge Manager")] public ChallengeManager manager;
    

    #endregion

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(transform.name + " has touched " + other.transform.name);
    }

    public void PopUp()
    {
        Debug.Log("Poping up");
    }

    public void DropDown()
    {
        Debug.Log("Dropping Down");
    }
}
