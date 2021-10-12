using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSetup : MonoBehaviour
{
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource[] audioSourceSoundEffects;
    // Start is called before the first frame update
    void Start()
    {
        musicAudioSource.volume = AudioSettings.volumeMusic;
        foreach (AudioSource audioSoundEffect in audioSourceSoundEffects)
        {
            audioSoundEffect.volume = AudioSettings.volumeSoundEffect;
        }
    }
}
