using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Objects")]
    public Text ammoTex;
    public Camera miniMapCamera;
    [Header("Variables")]
    [Range(0,2)]
    public int miniMapZoom;
    [Header("Scripts")]
    public CharacterController cController;
    public UserSettings settings;

    private void Start()
    {
        settings = GameObject.Find("DDOL").GetComponent<UserSettings>();
    }
    private void Update()
    {
        if (cController.currentWep == 1)
        {
            ammoTex.text = cController.weapon1CurrentAmmo + "";
        }
        else
        {
            ammoTex.text = cController.weapon2CurrentAmmo + "";
        }

        if (Input.GetKeyDown(settings.cMMView))
        {
            miniMapZoom++;
            if (miniMapZoom >= 3)
            {
                miniMapZoom = 0;
            }
        }

        if (miniMapZoom == 0)
        {
            miniMapCamera.orthographicSize = 5;
        }
        else if(miniMapZoom == 1)
        {
            miniMapCamera.orthographicSize = 10;
        }
        else if (miniMapZoom == 2)
        {
            miniMapCamera.orthographicSize = 15;
        }
        
    }
}
