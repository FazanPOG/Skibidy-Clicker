using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraManHeaderUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cameraManNameText;
    [SerializeField] private TextMeshProUGUI cameraManBuyCountText;
    [SerializeField] private Image background;
    [SerializeField] private Color[] backgroundRarityColors;
    [SerializeField] private CameraManBuyButton cameraManBuyButton;

    private CameraMan cameraMan;

    private void Awake()
    {
        cameraMan = GetComponentInParent<CameraMan>();
    }
    private void Start()
    {
        SetCameraManNameText();
        UpdateCameraManCount();
        SetBackgroundRarityColor();

        cameraManBuyButton.OnBoughtCameraMan += CameraManBuyButton_OnBoughtCameraMan;
    }

    private void CameraManBuyButton_OnBoughtCameraMan(double cost)
    {
        UpdateCameraManCount();
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
    private void SetCameraManNameText() 
    {
        cameraManNameText.text = cameraMan.GetCameraManName();
    }
    private void UpdateCameraManCount() 
    {
        int cameraManBuyCount = cameraManBuyButton.GetBuyCount();

        cameraManBuyCountText.text = cameraManBuyCount + "/" + cameraMan.GetCameraManBuyCountMax().ToString();
    }

}
