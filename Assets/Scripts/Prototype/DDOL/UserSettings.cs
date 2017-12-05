using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSettings : MonoBehaviour
{
    [Header("Users Controlls")]
    public KeyCode cPause;
    //In-Game
    public KeyCode cLeft, cRight, cBackwards, cForwards, cJump,cADS, cShoot,cMMView, cInteract;
    //Other
    [Header("In Game Settings")]
    //Mouse
    public float igsAimSens;
    //Movement
    public bool igsTogADS,igsTogCrouch,igsTogLean;
    [Header("Graphics")]
    [Range(0,2)]
    [Tooltip("0 = Fullscreen 1 = Borderless 2 = Windowed")]
    public int gWindowMode;
    [Range(0,3)]
    [Tooltip("0 = Low 1 = Normal 2 = High 3 = Extreme")]
    public int gViewDis;
}
