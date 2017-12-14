using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeMenu : MonoBehaviour 
{
    #region Variables

    public ChallengeInfo[] info;
    public Text[] buttons;

    public Text challenge_NameText, challenge_DecText,challenge_PScoreText;

    #endregion

    private void Start()
    {
        for (int i = 0; i < info.Length; i++)
        {
            Debug.Log(i);
            buttons[i].text = info[i].challenge_Name;
        }
    }

    public void UpdateInfo(int challenge)
    {
        challenge_NameText.text = info[challenge].challenge_Name;
        challenge_DecText.text = info[challenge].challenge_Dec;
        if (info[challenge].challenge_PScore == 0)
        {
            challenge_PScoreText.text = "You have no best time set.";
        }
        else
        {
            challenge_PScoreText.text = "Your best time is: " + info[challenge].challenge_PScore;
        }
        
    }
    
    
    
}
