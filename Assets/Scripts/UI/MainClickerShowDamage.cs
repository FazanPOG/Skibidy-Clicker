using UnityEngine;

public class MainClickerShowDamage : MonoBehaviour
{
    [SerializeField] private GameObject showDamagePrefab;
    [SerializeField] private Transform parentTransform;

    private void Start()
    {
        ScoreManager.Instance.OnScoreChanged += ScoreManager_OnScoreChanged;
    }

    private void ScoreManager_OnScoreChanged()
    {
        InstantiateShowDamagePrefab();
    }

    private void InstantiateShowDamagePrefab() 
    {
        GameObject newShowDamageObject = Instantiate(showDamagePrefab, parentTransform);
        RectTransform rectTransform = newShowDamageObject.GetComponent<RectTransform>();

        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rectTransform.anchoredPosition = Vector2.zero;


        Destroy(newShowDamageObject, 2f);
    }
}
