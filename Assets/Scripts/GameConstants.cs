
using UnityEngine;

public class GameConstants
{
    public static float MovementOffset=1.2f;
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
    public static float ItemTime = 10f;
    public static float AngryRate = 1.2f;
    public static float NormalRate = 0.6f;
}
