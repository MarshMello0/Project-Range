using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    [Header("Settings")]
    public float compDeg;
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
        compDeg = playerTra.localRotation.y;
        compDegText.text = compDeg + "";
    }

}
