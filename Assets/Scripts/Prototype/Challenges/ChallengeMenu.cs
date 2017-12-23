using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeMenu : MonoBehaviour 
{
    #region Variables

    #region ChallengeVariables

    public ChallengeInfo[] info;
    public Text[] buttons;

    public Text challenge_NameText, challenge_DecText,challenge_PScoreText,challenge_WepText,challenge_StartText;
    public Button challenge_StartButton;

    #endregion

    public GameObject[] menu_GameObjects;
    public GameObject[] challenge_GameObjects;
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
        challenge_WepText.text = "Weapon: " + info[challenge].challenge_wepaon.ToString();
        if (info[challenge].challenege_Unlocked)
        {
            challenge_StartText.text = "Start!";
            challenge_StartButton.interactable = true;
            challenge_StartButton.onClick.AddListener((delegate { StartChallenge(challenge); }));
        }
        else
        {
            challenge_StartText.text = "Locked";
            challenge_StartButton.interactable = false;
        }
    }

    public void StartChallenge(int challenge)
    {
        for (int a = 0; a < menu_GameObjects.Length;a++)
        {
            menu_GameObjects[a].SetActive(false);
        }
        for (int i = 0; i < challenge_GameObjects.Length; i++)
        {
            challenge_GameObjects[i].SetActive(true);
        }
        Debug.Log(challenge);
    }
    
}
