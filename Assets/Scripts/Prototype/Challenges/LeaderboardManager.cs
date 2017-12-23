using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public ChallengeLeaderboard leaderboard;

    void Init()
    {
        if (leaderboard.challenge_Dictionary != null)
            return;
        leaderboard.challenge_Dictionary = new Dictionary<string, Dictionary<string,int>>();
    }

    public int GetScore(string username, string scoreType)
    {
        Init();
        if (leaderboard.challenge_Dictionary.ContainsKey(username) == false)
        {
            //We have no score record at all for this username
            return 0;
        }
        if (leaderboard.challenge_Dictionary.ContainsKey(scoreType) == false)
        {
            //We have no score record at all for this scoretype
            return 0;
        }
        return leaderboard.challenge_Dictionary[username][scoreType];
    }

    public void SetScore(string username, string scoreType, int value)
    {
        Init();
        if (leaderboard.challenge_Dictionary.ContainsKey(username) == false)
        {
            leaderboard.challenge_Dictionary[username] = new Dictionary<string, int>();
        }

        leaderboard.challenge_Dictionary[username][scoreType] = value;
    }
    
}
