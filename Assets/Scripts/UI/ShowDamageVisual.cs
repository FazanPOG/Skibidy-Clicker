using System.Collections;
using TMPro;
using UnityEngine;

public class ShowDamageVisual : MonoBehaviour
{
    private TextMeshProUGUI showDamageText;
    private Vector3 randomSpawnPosition;

    private void Awake()
    {
        showDamageText = GetComponentInChildren<TextMeshProUGUI>(); 
    }

    private void Start()
    {
        double damage = ScoreManager.Instance.GetLastScoreRaise();

        string numberOfZeroes;
        damage = ScoreManager.Instance.CountValue(damage, out numberOfZeroes);

        showDamageText.text = "+" + damage.ToString() + " " + numberOfZeroes;

        randomSpawnPosition = SetRandomSpawnPosition();

        DamageAnimation();
    }

    private void Update()
    {
        DamageMove();
    }

    private void DamageMove() 
    {
        float damageMoveSpeed = Random.Range(10f, 200f);

        transform.Translate(randomSpawnPosition * Time.deltaTime * damageMoveSpeed);
    }

    private Vector3 SetRandomSpawnPosition() 
    {
        Vector3 randomPosition = Random.insideUnitCircle.normalized;
        return randomPosition;
    }

    private void DamageAnimation() 
    {
        StartCoroutine(TransparencyChanged());
    }

    IEnumerator TransparencyChanged() 
    {
        float duration = 2f;
        float startAlpha = 1f;
        float endAlpha = 0f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float currentAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);

            Color newColor = showDamageText.color;
            newColor.a = currentAlpha;
            showDamageText.color = newColor;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        Color finalColor = showDamageText.color;
        finalColor.a = endAlpha;
        showDamageText.color = finalColor;
        
    }
}
