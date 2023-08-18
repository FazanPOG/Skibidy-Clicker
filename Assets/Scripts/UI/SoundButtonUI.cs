using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundButtonUI : MonoBehaviour
{
    private Button soundButton;
    private bool isSoundOn = true;

    public static event Action<bool> OnSwitchSound;

    private void Awake()
    {
        soundButton = GetComponentInChildren<Button>();
    }

    private void Start()
    {
        soundButton.onClick.AddListener(() => 
        {
            isSoundOn = !isSoundOn;
            OnSwitchSound?.Invoke(isSoundOn);
        });
    }

}
