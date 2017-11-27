using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    [Header("Settings")]
    public int compDeg;
    public string compDir;
    [Header("Objects")]
    public Text compDegText;
    public Text compDirText;
    public Transform playerTra;
    private void Update()
    {
        UpdateDegree();
    }

    void UpdateDegree()
    {
        compDeg = Mathf.RoundToInt(playerTra.localRotation.eulerAngles.y);
        compDegText.text = compDeg + "";

        /*
        337.6 to 22.5 = N
        22.6 to  67.5 = NE
        67.6 to 112.5 = E
        112.6 to 157.5 = SE
        157.6 to 202.5 = S
        202.6 to 247.5 = SW
        247.6 to 292.5 = W
        292.6 to 337.5 = NW
         */

        if (playerTra.localRotation.eulerAngles.y > 337.5f || playerTra.localRotation.eulerAngles.y < 22.6f)
        {
            //N
            compDirText.text = "N";
        }
        else if (playerTra.localRotation.eulerAngles.y > 22.5f && playerTra.localRotation.eulerAngles.y < 67.6f)
        {
            //NE
            compDirText.text = "NE";
        }
        else if (playerTra.localRotation.eulerAngles.y > 67.5f && playerTra.localRotation.eulerAngles.y < 112.6f)
        {
            //E
            compDirText.text = "E";
        }
        else if (playerTra.localRotation.eulerAngles.y > 112.5f && playerTra.localRotation.eulerAngles.y < 157.6f)
        {
            //SE
            compDirText.text = "SE";
        }
        else if (playerTra.localRotation.eulerAngles.y > 157.5f && playerTra.localRotation.eulerAngles.y < 202.6f)
        {
            //S
            compDirText.text = "S";
        }
        else if (playerTra.localRotation.eulerAngles.y > 202.5f && playerTra.localRotation.eulerAngles.y < 247.6f)
        {
            //SW
            compDirText.text = "SW";
        }
        else if (playerTra.localRotation.eulerAngles.y > 247.5f && playerTra.localRotation.eulerAngles.y < 292.6f)
        {
            //W
            compDirText.text = "W";
        }
        else if (playerTra.localRotation.eulerAngles.y > 292.5f && playerTra.localRotation.eulerAngles.y < 337.6f)
        {
            //NW
            compDirText.text = "NW";
        }
    }

}
