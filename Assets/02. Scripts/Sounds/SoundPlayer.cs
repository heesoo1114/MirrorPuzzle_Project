using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : PoolableMono
{
    private AudioSource _audioSource;
    private float time = 0;
    public Util.Bgm nowLoopBgm = Util.Bgm.None;

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

    public void PlayLoopSound(AudioClip clip, Util.Bgm bgmName)
    {
        nowLoopBgm = bgmName;
        _audioSource.clip = clip;
        _audioSource.loop = true;
        _audioSource.Play();
    }

    public void PlayStopAndPush()
    {
        Reset();
        time = 0;
        nowLoopBgm = Util.Bgm.None;
        _audioSource.Stop();
        PoolManager.Instance.Push(this);
    }

    private void Update()
    {
        if (_audioSource.loop == true) return;

        time += Time.deltaTime;
        if (time >= _audioSource.clip.length)
            PlayStopAndPush();
    }

    public override void Reset()
    {
        time = 0;
    }
}
