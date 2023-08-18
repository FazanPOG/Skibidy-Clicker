using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class ScoreManager : MonoBehaviour
{
    private const string THOUSAND_TEXT = "Тысяч";
    private const string MILLION_TEXT = "Mиллионов";
    private const string BILLION_TEXT = "Mиллиаpдов";

    [SerializeField] private Button mainClickerButton;
    [SerializeField] private double score;
    [SerializeField] private int scorePerSecond;
    [SerializeField] private int scorePerClick = 1;

    private int lastScoreRaise;

    public static ScoreManager Instance;

    public event Action OnScoreChanged;
    public event Action OnScorePerSecondChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("More than one Instance (ScoreManager)");
        }

        LoadData();
    }

    private void Start()
    {

        StartCoroutine(IncreaseScoreEverySecond());

        mainClickerButton.onClick.AddListener(() =>
        {
            score += scorePerClick;
            //Save
            SaveScore();
            lastScoreRaise = scorePerClick;
            OnScoreChanged?.Invoke();
        });

        CameraManBuyButton.OnBoughtCameraManScoreChanged += CameraManBuyButton_OnBoughtCameraManScoreChanged;
        YandexGame.RewardVideoEvent += YandexGame_RewardVideoEvent;
    }
   
    private void OnDestroy()
    {
        CameraManBuyButton.OnBoughtCameraManScoreChanged -= CameraManBuyButton_OnBoughtCameraManScoreChanged;
        YandexGame.RewardVideoEvent -= YandexGame_RewardVideoEvent;
    }

    private void YandexGame_RewardVideoEvent(int bonus)
    {
        scorePerSecond += bonus;
        //Save
        SaveScorePerSecond();
        OnScorePerSecondChanged?.Invoke();
    }

    private void CameraManBuyButton_OnBoughtCameraManScoreChanged(CameraMan cameraMan, CameraManBuyButton cameraManBuyButton)
    {
        double cameraManCost = cameraManBuyButton.GetNewCameraManCost();
        bool cameraManPerClickBonus = cameraMan.IsCameraManScorePerClickBonus();
        bool cameraManPerSecondBonus = cameraMan.IsCameraManScorePerSecondBonus();

        score -= cameraManCost;
        //Save
        SaveScore();
        OnScoreChanged?.Invoke();

        if (cameraManPerClickBonus) 
        {
            int bonus = cameraMan.GetCameraManBonus();
            scorePerClick += bonus;
            //Save
            SaveScorePerClick();
        }
        if (cameraManPerSecondBonus) 
        {
            int bonus = cameraMan.GetCameraManBonus();
            scorePerSecond += bonus;
            //Save
            SaveScorePerSecond();
            OnScorePerSecondChanged?.Invoke();
        }
    }

    private IEnumerator IncreaseScoreEverySecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            score += scorePerSecond;
            //Save
            SaveScore();
            lastScoreRaise = scorePerSecond;
            OnScoreChanged?.Invoke();
        }
    }

    public double GetScore() 
    {
        return score;
    }
    public int GetScorePerSecond() 
    {
        return scorePerSecond;
    }
    public int GetLastScoreRaise()
    {
        return lastScoreRaise;
    }

    public double CountValue(double value ,out string numberOfZeros)
    {
        numberOfZeros = "";

        if (value >= 1000000000)
        {
            numberOfZeros = BILLION_TEXT;
            value /= 1000000000;
            value = Math.Round(value, 2);
        }
        else if (value >= 1000000)
        {
            numberOfZeros = MILLION_TEXT;
            value /= 1000000;
            value = Math.Round(value, 2);
        }
        else if (value >= 1000)
        {
            numberOfZeros = THOUSAND_TEXT;
            value /= 1000;
            value = Math.Round(value, 3);
        }

        return value;
    }
    private void SaveScore() 
    {
        SaveManager.SaveDouble(SaveManager.SCORE_KEY, score);
    }

    private void SaveScorePerSecond()
    {
        SaveManager.SaveInt(SaveManager.SCORE_PER_SECOND_KEY, scorePerSecond);
    }

    private void SaveScorePerClick()
    {
        SaveManager.SaveInt(SaveManager.SCORE_PER_CLICK_KEY, scorePerClick);
    }

    private void LoadData()
    {
        score = SaveManager.LoadDouble(SaveManager.SCORE_KEY, score);
        scorePerSecond = SaveManager.LoadInt(SaveManager.SCORE_PER_SECOND_KEY, scorePerSecond);
        scorePerClick = SaveManager.LoadInt(SaveManager.SCORE_PER_CLICK_KEY, scorePerClick);
    }
}
