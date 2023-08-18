using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraManBuyButtonUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cameraManCostText;
    [SerializeField] private TextMeshProUGUI cameraManBonusText;
    [SerializeField] private Image cameraManImage;
    [SerializeField] private Color[] backgroundRarityColors;
    [SerializeField] private Color backgroundCantBuyColor;

    private CameraManBuyButton cameraManBuyButton;
    private Image background;
    private CameraMan cameraMan;

    private void Awake()
    {
        cameraManBuyButton = GetComponent<CameraManBuyButton>();
        background = GetComponent<Image>();
        cameraMan = GetComponentInParent<CameraMan>();

        cameraManBuyButton.OnCostChange += CameraManBuyButton_OnCostChange;
    }

    private void Start()
    {
        SetCameraManBonusText();
        SetBackgroundRarityColor();
        SetCameraManSprite();

        ScoreManager.Instance.OnScoreChanged += ScoreManager_OnScoreChanged;
    }

    private void ScoreManager_OnScoreChanged()
    {
        double cameraManCost = cameraManBuyButton.GetNewCameraManCost();
        double score = ScoreManager.Instance.GetScore();
        if (score < cameraManCost) 
        {
            background.color = backgroundCantBuyColor;
        }
        else 
        {
            SetBackgroundRarityColor();
        }
    }

    private void CameraManBuyButton_OnCostChange(double cost)
    {
        double cameraManCost = cost;

        string numberOfZeroes;
        double countCameraManCost = ScoreManager.Instance.CountValue(cameraManCost, out numberOfZeroes);

        cameraManCostText.text = countCameraManCost.ToString() + " " + numberOfZeroes;
    }

    private void SetBackgroundRarityColor()
    {
        CameraManSO.Rarity cameraManRarity = cameraMan.GetCameraManRarity();
        switch (cameraManRarity)
        {
            case CameraManSO.Rarity.Common:
                background.color = backgroundRarityColors[0];
                break;

            case CameraManSO.Rarity.Uncommon:
                background.color = backgroundRarityColors[1];
                break;

            case CameraManSO.Rarity.Rare:
                background.color = backgroundRarityColors[2];
                break;

            case CameraManSO.Rarity.Epic:
                background.color = backgroundRarityColors[3];
                break;

            case CameraManSO.Rarity.Legendary:
                background.color = backgroundRarityColors[4];
                break;
        }
    }
    private void SetCameraManBonusText()
    {
        bool isScorePerSecondBonus = cameraMan.IsCameraManScorePerSecondBonus();
        int cameraManBonus = cameraMan.GetCameraManBonus();

        string numberOfZeroes;
        double countCameraManBonus = ScoreManager.Instance.CountValue(cameraManBonus, out numberOfZeroes);

        if (isScorePerSecondBonus)
        {
            cameraManBonusText.text = countCameraManBonus.ToString() + " " + numberOfZeroes + " шт. в секунду";
        }
        else
        {
            cameraManBonusText.text = "за клик +" + countCameraManBonus.ToString() + " " + numberOfZeroes;
        }
    }
    private void SetCameraManSprite()
    {
        Sprite cameraManSprite = cameraMan.GetCameraManSprite();
        cameraManImage.sprite = cameraManSprite;
    }

}
