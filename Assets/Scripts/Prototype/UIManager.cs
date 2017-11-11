using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Objects")]
    public Text ammoTex;
    [Header("Scripts")]
    public CharacterController cController;


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
        
    }
}
