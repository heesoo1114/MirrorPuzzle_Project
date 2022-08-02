using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _effectSlider;

    private void Start()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("Music");
        _effectSlider.value = PlayerPrefs.GetFloat("Effect");
        _audioMixer.SetFloat("Music", PlayerPrefs.GetFloat("Music"));
        _audioMixer.SetFloat("Effect", PlayerPrefs.GetFloat("Effect"));
    }

    public void SetMusicVolume(float value)
    {
        _audioMixer.SetFloat("Music", value);
        PlayerPrefs.SetFloat("Music", value);
    }

    public void SetEffectVolume(float value)
    {
        _audioMixer.SetFloat("Effect", value);
        PlayerPrefs.SetFloat("Effect", value);
    }
}
