
using UnityEngine;

public class GameConstants
{
    public static  int Player1Score;
    public static int Player2Score;
    public static float activationdistance = 0.62f;
    public static float MovementOffset=2f;
    public static float choptime=2f;
    public static string[] vegetablenames = { "a", "b", "c", "d", "e", "f" };
    public static int maxitems = 3;
    public static float nextCustomerTime = 7f;
    public enum Players
    {
        Player1,
        Player2
    }
    public static Color NormalColor= Color.green;
    public static Color AngryColor = Color.red;
    public static float ItemTime = 30f;
    public static float AngryRate = 1.2f;
    public static float NormalRate = 0.6f;
    public static float IntialTime = 300;
    public static int correctcomboScore = 50;
    public static int wrongcomboScore = -25;
    public static int normalcustomerleave = -20;
    public static int angrycustomerleave = -40;
    public static int vegetabletrash = -5;
    public static int combinationtrash = -10;
    public static int ScorePickUp = 40;
    public static int TimePickup = 30;
    public static float HappyPercent = 0.7f;
    public static float SpeedPickUpTime = 5f;
    public static float IncreasedSpeed = 4f;
}
