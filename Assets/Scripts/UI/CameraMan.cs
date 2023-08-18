using UnityEngine;

public class CameraMan : MonoBehaviour
{
    [SerializeField] private CameraManSO cameraManSO;

    public float commonBuy—oefficient {get; private set;}
    public float unCommonBuy—oefficient { get; private set;}
    public float rareBuy—oefficient { get; private set; }
    public float epicBuy—oefficient { get; private set; }
    public float legendaryBuy—oefficient { get; private set; }

    private void Awake()
    {
        commonBuy—oefficient = 1.25f;
        unCommonBuy—oefficient = 1.5f;
        rareBuy—oefficient = 1.75f;
        epicBuy—oefficient = 2f;
        legendaryBuy—oefficient = 2.25f;
    }

    public string GetCameraManName() 
    {
        return cameraManSO.Name;
    }
    public int GetCameraManBuyCountMax()
    {
        return cameraManSO.BuyCountMax;
    }
    public int GetCameraManBonus()
    {
        return cameraManSO.Bonus;
    }
    public bool IsCameraManScorePerSecondBonus()
    {
        return cameraManSO.IsScorePerSecondBonus;
    }
    public bool IsCameraManScorePerClickBonus()
    {
        return cameraManSO.IsScorePerClickBonus;
    }
    public double GetCameraManCost()
    {
        return cameraManSO.Cost;
    }
    public Sprite GetCameraManSprite()
    {
        return cameraManSO.CameraManSprite;
    }
    public CameraManSO.Rarity GetCameraManRarity()
    {
        return cameraManSO.rarity;
    }
}
