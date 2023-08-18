using UnityEngine;
using UnityEngine.UI;

public class MarketUI : MonoBehaviour
{
    [SerializeField] private Button marketButton;
    [SerializeField] private Button mainClickerButton;

    private void Start()
    {
        marketButton.onClick.AddListener(() => 
        {
            Show();
        });

        mainClickerButton.onClick.AddListener(() =>
        {
            Hide();
        });

        Hide();
    }

    private void Show() 
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
