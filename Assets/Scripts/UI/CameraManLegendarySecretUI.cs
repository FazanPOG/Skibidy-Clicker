using UnityEngine;
using UnityEngine.UI;

public class CameraManLegendarySecretUI : MonoBehaviour
{
    [SerializeField] private Image cameraManImage;
    [SerializeField] private Sprite cameraManNewSprite;

    private CameraMan cameraMan;
    private CameraManBuyButton cameraManBuyButton;
    private int cameraManBuyCount = 0;
    private int cameraManBuyCountMax;
    private void Awake()
    {
        cameraMan = GetComponent<CameraMan>();
        cameraManBuyButton = GetComponentInChildren<CameraManBuyButton>();
    }

    private void Start()
    {
        cameraManBuyCountMax = cameraMan.GetCameraManBuyCountMax();
        cameraManBuyButton.OnBoughtCameraMan += CameraManBuyButton_OnBoughtCameraMan;

        if (cameraManBuyCount == cameraManBuyCountMax)
        {
            cameraManImage.sprite = cameraManNewSprite;
        }
    }

    private void CameraManBuyButton_OnBoughtCameraMan(double cost)
    {
        cameraManBuyCount++;
        if (cameraManBuyCount == cameraManBuyCountMax) 
        {
            cameraManImage.sprite = cameraManNewSprite;
        }
    }
}
