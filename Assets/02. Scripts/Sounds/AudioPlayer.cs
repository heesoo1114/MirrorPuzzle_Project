using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private float _randnessPitch = 0.2f;

    private AudioSource _audioSource;
    private float _basePitch;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _basePitch = _audioSource.pitch;
    }

    protected void PlayClipWithRandnessPitch(AudioClip clip)
    {
        _audioSource.pitch = _basePitch + Random.Range(-_randnessPitch, _randnessPitch);

        PlayClip(clip);
    }

    protected void PlayClip(AudioClip clip)
    {
        _audioSource.Stop();
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
