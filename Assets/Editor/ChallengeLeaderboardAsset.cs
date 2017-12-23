using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ChallengeLeaderboardAsset : ScriptableObject {
	[MenuItem("Assets/Create/ChallengeLeaderboards")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<ChallengeLeaderboard>();
	}
}
