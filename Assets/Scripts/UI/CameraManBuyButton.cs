using System;
using UnityEngine;
using UnityEngine.UI;

public class CameraManBuyButton : MonoBehaviour
{
    private Button cameraManBuyButton;
    private CameraMan cameraMan;
    private int buyCount = 0;
    private double cameraManCost;

    public event Action<double> OnBoughtCameraMan;
    public event Action<double> OnCostChange;
    public static event Action<CameraMan, CameraManBuyButton> OnBoughtCameraManScoreChanged;

    private void Awake()
    {
        cameraManBuyButton = GetComponent<Button>();
        cameraMan = GetComponentInParent<CameraMan>();

        LoadData();
    }

    private void Start()
    {
        if (buyCount > 0)
        {
            CountCameraManCost(buyCount);
        }
        else
        {
            cameraManCost = cameraMan.GetCameraManCost();
        }

        OnCostChange?.Invoke(cameraManCost);
       
        cameraManBuyButton.onClick.AddListener(TryBuy);

    }

    private void OnDestroy()
    {
        //SaveData();
    }

    private void TryBuy() 
    {
        double score = ScoreManager.Instance.GetScore();
        int buyCountMax = cameraMan.GetCameraManBuyCountMax();

        if (score >= cameraManCost && buyCount < buyCountMax) 
        {
            buyCount++;

            OnBoughtCameraManScoreChanged?.Invoke(cameraMan, this);

            Debug.Log("�������� - " + cameraManCost);

            CountCameraManCost(buyCount);
            OnCostChange?.Invoke(cameraManCost);
            OnBoughtCameraMan?.Invoke(cameraManCost);

            Debug.Log("����� ���� - " + cameraManCost);

            //Save
            SaveData();

            SoundManager.Instance.PlayBuyButtonSound();
        }
    }

    private void CountCameraManCost(int buyCount) 
    {
        CameraManSO.Rarity rarity = cameraMan.GetCameraManRarity();

        switch (rarity)
        {
            case CameraManSO.Rarity.Common:
                cameraManCost = cameraMan.GetCameraManCost() * buyCount * cameraMan.commonBuy�oefficient;
                break;

            case CameraManSO.Rarity.Uncommon:
                cameraManCost = cameraMan.GetCameraManCost() * buyCount * cameraMan.unCommonBuy�oefficient;
                break;

            case CameraManSO.Rarity.Rare:
                cameraManCost = cameraMan.GetCameraManCost() * buyCount * cameraMan.rareBuy�oefficient;
                break;

            case CameraManSO.Rarity.Epic:
                cameraManCost = cameraMan.GetCameraManCost() * buyCount * cameraMan.epicBuy�oefficient;
                break;

            case CameraManSO.Rarity.Legendary:
                cameraManCost = cameraMan.GetCameraManCost() * buyCount * cameraMan.legendaryBuy�oefficient;
                break;
        }
    }

    public int GetBuyCount() 
    {
        return buyCount;
    }

    public double GetNewCameraManCost() 
    {
        return cameraManCost;
    }

    private void SaveData()
    {
        SaveManager.SaveInt(SaveManager.BUY_COUNT_KEY + cameraMan.GetCameraManName(), buyCount);
        SaveManager.SaveDouble(SaveManager.COST_KEY + cameraMan.GetCameraManName(), cameraManCost);
    }
    private void LoadData()
    {
        buyCount = SaveManager.LoadInt(SaveManager.BUY_COUNT_KEY + cameraMan.GetCameraManName());
        //cameraManCost = SaveManager.LoadDouble(SaveManager.COST_KEY + cameraMan.GetCameraManName());
    }

}
