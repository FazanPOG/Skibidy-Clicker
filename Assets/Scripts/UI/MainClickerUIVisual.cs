using UnityEngine;

public class MainClickerUIVisual : MonoBehaviour
{
    private const string MAIN_CLIKER_BUTTON_ON_CLICK_TRIGGER = "MainClickerButtonOnClick";

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        ScoreManager.Instance.OnScoreChanged += ScoreManager_OnScoreChanged;
    }

    private void ScoreManager_OnScoreChanged()
    {
        animator.SetTrigger(MAIN_CLIKER_BUTTON_ON_CLICK_TRIGGER);
    }
}
