using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private SoundReferencesSO soundReferencesSO;

    private AudioSource uiAudioSource;

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        uiAudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        SoundButtonUI.OnSwitchSound += SoundButtonUI_OnSwitchSound;
    }

    private void OnDestroy()
    {
        SoundButtonUI.OnSwitchSound -= SoundButtonUI_OnSwitchSound;
    }

    private void SoundButtonUI_OnSwitchSound(bool isSoundOn)
    {
        if (isSoundOn)
        {
            uiAudioSource.mute = false;
        }
        else
        {
            uiAudioSource.mute = true;
        }
    }

    public void PlayNavigationMenuButtonSound() 
    {
        uiAudioSource.PlayOneShot(soundReferencesSO.navigationMenuButtonsAudioClip);
    }

    public void PlayMainClikerSound() 
    {
        uiAudioSource.PlayOneShot(soundReferencesSO.mainClickerAudioClip);
    }

    public void PlayBuyButtonSound()
    {
        uiAudioSource.PlayOneShot(soundReferencesSO.buyButtonAudioClip);
    }

}
