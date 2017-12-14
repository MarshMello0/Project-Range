using UnityEngine;
using UnityEngine.UI;

public enum Weapons_Restriction
{
    M9
}
public class ChallengeInfo : ScriptableObject
{
    [Header("Challenge Info")] 
    public string challenge_Name;
    public string challenge_Dec;
    public int challenge_PScore;
    [Header("Settings for challange")] 
    public int challenge_GoldPoints;
    public int challenge_SliverPoints;
    public int challenge_BronzePoints;
    public float challenge_GoldTime;
    public float challenge_SliverTime;
    public float challenge_BronzeTime;
    [Header("Challange Rules")]
    public Weapons_Restriction challenge_wepaon;

}
