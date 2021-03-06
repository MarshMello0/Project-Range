﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TargetControllerBasic : MonoBehaviour
{ 
    #region Variabes
    [Header("This must be attacted to the targets gameobject")]

    [Space]

    [Header("Settings")]
    [SerializeField][Tooltip("This is which axis is will move along out of x and z")]private bool moveOnX;
    [SerializeField][Tooltip("if to invert the one above")]private bool axisInverted;
    [Tooltip("This is the furthest point it can go")]public float targetEndDis;
    [SerializeField][Tooltip("This is if its poped up")]private bool isPoped;
    [Tooltip("This is the distance its gonna move to")]public float aimedDis;
    [Tooltip("This is the speed its gonna take to move to aimeddis")][Range(0.001f,2)]public float moveTime;

    [Header("Copy and paste currents transforms position in here so gizmos in editor line is correct")]
    [SerializeField][Tooltip("This is the start point(This will get set to a point in space on start of game)")]private Vector3 startPos;

    [Space]
    [Header("Text for dis")]
    [SerializeField] private Text disText;
    [Space]

    [SerializeField][Tooltip("This is if its at the start(This will change its self to true at start)")]private bool atStart;
    [SerializeField][Tooltip("This is the current distance(This will change to 0 at start)")]private float currentDis;

    public bool isMoving;

    #endregion
    private void Start()
    {
        atStart = true;
        currentDis = 0;
        startPos = transform.position;
    }
    private void Update()
    {
        disText.text = (currentDis + 5) + "m";
        #region movementAlongLine
        if (currentDis > targetEndDis)
        {
            currentDis = targetEndDis;
        }
        else if (currentDis < 0)
        {
            currentDis = 0;
        }
        if (moveOnX && !axisInverted)
        {
            transform.position = new Vector3(startPos.x + currentDis, transform.position.y, transform.position.z);
        }
        else if (!moveOnX && !axisInverted)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, startPos.z + currentDis);
        }
        else if (moveOnX && axisInverted)
        {
            transform.position = new Vector3(startPos.x - currentDis, transform.position.y, transform.position.z);
        }
        else if (!moveOnX && axisInverted)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, startPos.z - currentDis);
        }
        #endregion
    }
    private void OnCollisionEnter(Collision collision)
    {
        print(transform.name + ": Some thing hit me");
    }

    private void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying)
        {
            startPos = transform.position;
        }
        Gizmos.color = Color.white;
        if (moveOnX && !axisInverted)
        {
            Gizmos.DrawLine(startPos, new Vector3(startPos.x + targetEndDis, startPos.y, startPos.z));
        }
        else if (!moveOnX && !axisInverted)
        {
            Gizmos.DrawLine(startPos, new Vector3(startPos.x, startPos.y, startPos.z + targetEndDis));
        }
        else if (moveOnX && axisInverted)
        {
            Gizmos.DrawLine(startPos, new Vector3(startPos.x - targetEndDis, startPos.y, startPos.z));
        }
        else if (!moveOnX && axisInverted)
        {
            Gizmos.DrawLine(startPos, new Vector3(startPos.x, startPos.y, startPos.z - targetEndDis));
        }
        else
        {
            Debug.LogError("Error OnDrawGizmosSelected - TargetControllerBasic");
        }
    }
    public IEnumerator MoveDown()
    {
        if (aimedDis < currentDis)
        {
            currentDis -= 0.3f;
            print("Moved Down");
            yield return new WaitForSeconds(moveTime);
            StartCoroutine("MoveDown");
        }
        else
        {
            isMoving = false;
        }
    }
    public IEnumerator MoveUp()
    {
        if (aimedDis > currentDis)
        {
            currentDis += 0.3f;
            print("Moved Up");
            yield return new WaitForSeconds(moveTime);
            StartCoroutine("MoveUp");
        }
        else
        {
            isMoving = false;
        }
    }
}
