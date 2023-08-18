using System;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreCounterText;
    [SerializeField] private TextMeshProUGUI scorePerSecondText;

    private void Start()
    {
        ScoreManager.Instance.OnScoreChanged += ScoreManager_OnScoreChanged;
        ScoreManager.Instance.OnScorePerSecondChanged += ScoreManager_OnScorePerSecondChanged;

        UpdateScorePerSecondVisual();
        UpdateScoreVisual();
    }

    private void ScoreManager_OnScorePerSecondChanged()
    {
        UpdateScorePerSecondVisual();
    }

    private void ScoreManager_OnScoreChanged()
    {
        UpdateScoreVisual();
    }

    private void UpdateScoreVisual() 
    {
        double score = ScoreManager.Instance.GetScore();
        string numberOfZeros;
        scoreCounterText.text = ScoreManager.Instance.CountValue(score ,out numberOfZeros).ToString() + " " + numberOfZeros;
    }
    private void UpdateScorePerSecondVisual()
    {
        double scorePerSecond = ScoreManager.Instance.GetScorePerSecond();
        string numberOfZeros;
        scorePerSecond = ScoreManager.Instance.CountValue(scorePerSecond, out numberOfZeros);
        scorePerSecondText.text = scorePerSecond.ToString() + " " + numberOfZeros + " в секунду";
    }
}
