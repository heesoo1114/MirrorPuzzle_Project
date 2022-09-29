using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoSingleton<SoundManager>
{
    SoundClips soundClips = null;

    private void Awake()
    {
        soundClips = GameObject.Find("SoundManage").GetComponent<SoundClips>();
    }

    public void EffectStart(Util.Effect effectName)
    {
        SoundPlayer g = PoolManager.Instance.Pop("SoundPlayer") as SoundPlayer;
        g.PlaySound(soundClips.GetClipToEnum(effectName));
    }

    public void BgmStart(Util.Bgm bgmName)
    {
        SoundPlayer g = PoolManager.Instance.Pop("SoundPlayer") as SoundPlayer;
        g.PlayLoopSound(soundClips.GetClipToEnum(bgmName));
    }
}
