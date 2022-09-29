using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : PoolableMono
{
    private AudioSource _audioSource;
    private float time = 0;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.loop = false;
        _audioSource.Play();
    }

    public void PlayLoopSound(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.loop = true;
        _audioSource.Play();
    }

    private void Update()
    {
        if (_audioSource.loop == true) return;

        time += Time.deltaTime;
        if (time >= _audioSource.clip.length)
        {
            Reset();
            _audioSource.Stop();
            PoolManager.Instance.Push(this);
        }
    }

    public override void Reset()
    {
        time = 0;
    }
}
