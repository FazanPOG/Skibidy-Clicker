using System;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class RewardAdButtonUI : MonoBehaviour
{
    private Button rewardAdButton;
    private float bonusCoefficient = 3.5f;

    private void Awake()
    {
        rewardAdButton = GetComponentInChildren<Button>();
    }

    private void Start()
    {
        rewardAdButton.onClick.AddListener(ShowRewardAd);
    }

    private void ShowRewardAd() 
    {
        YandexGame.RewVideoShow(0);
        int bonus = CalculateBonus();
        YandexGame.RewardVideoEvent?.Invoke(bonus);
    }

    private int CalculateBonus() 
    {
        int scorePerSecond = ScoreManager.Instance.GetScorePerSecond();
        double bonus = Math.Round(scorePerSecond / bonusCoefficient);
        if (bonus < 10) 
        {
            bonus = 10;
        }
        return (int)bonus;
    }
}
