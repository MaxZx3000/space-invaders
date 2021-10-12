using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Options : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourceMusic;
    [SerializeField] private AudioSource audioSourceSoundEffect;
    [SerializeField] private Toggle toggle;
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderSoundEffect;
    private bool fullScreen;
    private float currentVolumeMusic;
    private float currentVolumeSoundEffect;
    void OnEnable()
    {
        currentVolumeMusic = audioSourceMusic.volume;
        currentVolumeSoundEffect = audioSourceSoundEffect.volume;
        fullScreen = Screen.fullScreen;
        toggle.isOn = fullScreen;
        sliderMusic.normalizedValue = audioSourceMusic.volume;
        sliderSoundEffect.normalizedValue = audioSourceSoundEffect.volume;
    }
    public void ApplyChanges()
    {
        AudioSettings.volumeMusic = sliderMusic.normalizedValue;
        AudioSettings.volumeSoundEffect = sliderSoundEffect.normalizedValue;
    }
    public void discardChanges()
    {
        audioSourceMusic.volume = currentVolumeMusic;
        audioSourceSoundEffect.volume = currentVolumeSoundEffect;
        AudioSettings.volumeMusic = currentVolumeMusic;
        AudioSettings.volumeSoundEffect = currentVolumeSoundEffect;
        Screen.fullScreen = fullScreen;
    }
    public void displayFullScreen(bool toggleIsOn)
    {
        Screen.fullScreen = toggleIsOn;
    }
}
