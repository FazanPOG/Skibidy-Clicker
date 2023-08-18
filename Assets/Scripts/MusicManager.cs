using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] musicAudioClips;

    private AudioSource musicSource;

    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayNextTrack();

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
            musicSource.mute = false;
        }
        else
        {
            musicSource.mute = true;
        }
    }

    private int currentTrackIndex = 0;


    private void PlayNextTrack()
    {
        musicSource.clip = musicAudioClips[currentTrackIndex];
        musicSource.Play();

        currentTrackIndex++;
        if (currentTrackIndex >= musicAudioClips.Length)
        {
            currentTrackIndex = 0;
        }

        StartCoroutine(WaitForMusicToEnd());
    }

    private IEnumerator WaitForMusicToEnd()
    {
        yield return new WaitForSeconds(musicSource.clip.length);
        PlayNextTrack();
    }
}
