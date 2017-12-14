using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ChallengeInfoAsset : ScriptableObject
{
    [MenuItem("Assets/Create/ChallengeInfo")]
    public static void CreateAsset()
    {
        ScriptableObjectUtility.CreateAsset<ChallengeInfo>();
    }
}
