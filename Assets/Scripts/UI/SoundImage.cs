using UnityEngine;
using UnityEngine.UI;

public class SoundImage : MonoBehaviour
{
    private Image soundImage;
    private Button soundButton;
    private bool soundOn = true;

    private void Awake()
    {
        soundImage = GetComponent<Image>();
        soundButton = GetComponentInParent<Button>();
    }

    private void Start()
    {
        soundButton.onClick.AddListener(() => 
        {
            if (soundOn) 
            {
                float soundOffAlpha = 0.5f;
                ChangeAlpha(soundOffAlpha);

                soundOn = false;
            }
            else 
            {
                float soundOnAlpha = 1;
                ChangeAlpha(soundOnAlpha);

                soundOn = true;
            }
        });
    }

    private void ChangeAlpha(float newAlpha) 
    {
        Color currentColor = soundImage.color;
        currentColor.a = newAlpha;
        soundImage.color = currentColor;
    } 
}
