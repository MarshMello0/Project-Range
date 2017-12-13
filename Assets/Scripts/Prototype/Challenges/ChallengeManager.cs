using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeManager : MonoBehaviour 
{
    /* Scripts Things
     Name of the challene
     Decription of the challenege
     gold score, sliver score,bronze score
     Have a list of the targets in this challenge
     Array of delays for each target when they pop up
     Array of delays for each target when they go down
     */

    #region Variables

    [Header("Settings")]
    [Tooltip("This is the name of the challenge which will show up")] public string challenge_Name;
    [Tooltip("This is the decription of the challenge")] public string challenge_Dec;
    [Space]
    [Tooltip("This is the time needed to complete for gold")] public float gold_Time;
    [Tooltip("This is the time needed to complete for sliver")] public float sliver_Time;
    [Tooltip("This is the time needed to complete for bronze")] public float bronze_Time;
    [Tooltip("This is the score given if the player reaches gold")] public int gold_Score;
    [Tooltip("This is the score given if the player reaches sliver")] public int sliver_Score;
    [Tooltip("This is the score given if the player reaches bronze")] public int bronze_Score;
    [Space]
    [Tooltip("This is the list of targets which are in this challenge")] public List<TargetController> targets_Controllers = new List<TargetController>();

    [Space] 
    [Tooltip("This is an array of the time delays for when the tartget pops up")] public float[] targets_PopUpDelay;
    [Tooltip("This is an array of the time delays for when the targets goes down if not hit")] public float[] targets_DropDelay;

    private bool isPlaying;
    
    #endregion

    private void Start()
    {
        if (targets_Controllers.Count == 0)
        {
            Debug.LogError(transform.name + "'s ChallengeManager is missing targets in the list. Fill out targets_Controllers");
        }
    }

    public IEnumerator StartChallenge()
    {
        Debug.Log(challenge_Name + " has started");
        for (int i = 0; i > targets_Controllers.Count; i++)
        {
            if (targets_Controllers[i].target_Number == 1)
            {
                yield return new WaitForSeconds(targets_PopUpDelay[i]);
                targets_Controllers[i].PopUp();
                yield return new WaitForSeconds(targets_DropDelay[i]);
                targets_Controllers[i].DropDown();
            }
        }
    }
}
