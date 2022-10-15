using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    [SerializeField]
    private SoundClips soundClips = null;

    private void Awake()
    {
        soundClips = GameObject.Find("SoundManage").GetComponent<SoundClips>(); // managers∑Œ πŸ≤„æﬂ«‘
    }

    public void EffectStart(Util.Effect effectName)
    {
        SoundPlayer g = PoolManager.Instance.Pop("SoundPlayer") as SoundPlayer;
        g.PlaySound(soundClips.GetClipToEnum(effectName));
    }

    public void BgmStart(Util.Bgm bgmName)
    {
        SoundPlayer g = PoolManager.Instance.Pop("SoundPlayer") as SoundPlayer;
        g.PlayLoopSound(soundClips.GetClipToEnum(bgmName), bgmName);
    }

    public void BgmStop(Util.Bgm bgmName)
    {
        SoundPlayer stopPlayer = null;
        SoundPlayer[] playToStop = null;
        playToStop = GameObject.Find("Test").GetComponentsInChildren<SoundPlayer>(); // ∏ﬁ¿Œæ¿ø°º± poolManager¿’¥¬¬ ¿∏∑Œ πŸ≤„æﬂ«‘
        foreach(SoundPlayer stop in playToStop)
        {
            if (stop.nowLoopBgm == bgmName)
            {
                stopPlayer = stop;
                break;
            }
        }
        if(stopPlayer == null)
        {
            Debug.LogWarning($"{bgmName} is not playing!");
            return;
        }
        stopPlayer.PlayStopAndPush();
    }
}
