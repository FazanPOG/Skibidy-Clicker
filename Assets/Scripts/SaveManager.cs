using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public const string SCORE_KEY = "Score";
    public const string SCORE_PER_SECOND_KEY = "ScorePerSecond";
    public const string SCORE_PER_CLICK_KEY = "ScorePerClick";
    public const string BUY_COUNT_KEY = "BuyCount";
    public const string COST_KEY = "Cost";

    private void Awake()
    {
        //ClearAllData();
    }

    private void ClearAllData() 
    {
        PlayerPrefs.DeleteAll();
    }

    public static void SaveInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);

        PlayerPrefs.Save();
    }

    public static int LoadInt(string key, int defaultValue = 0)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    public static void SaveDouble(string key, double value)
    {
        string stringValue = value.ToString("R"); 
        PlayerPrefs.SetString(key, stringValue);
        PlayerPrefs.Save();
    }

    public static double LoadDouble(string key, double defaultValue = 0.0)
    {
        string stringValue = PlayerPrefs.GetString(key, defaultValue.ToString());
        double value;
        if (double.TryParse(stringValue, out value))
        {
            return value;
        }
        else
        {
            return defaultValue;
        }
    }
}
