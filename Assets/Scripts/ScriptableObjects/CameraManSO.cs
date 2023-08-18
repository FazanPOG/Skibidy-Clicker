using UnityEngine;

[CreateAssetMenu()]
public class CameraManSO : ScriptableObject
{
    public string Name;
    public int BuyCountMax;
    public int Bonus;
    public bool IsScorePerSecondBonus;
    public bool IsScorePerClickBonus;
    public double Cost;
    public Sprite CameraManSprite;
    public Rarity rarity;

    public enum Rarity 
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary,
    }
}
