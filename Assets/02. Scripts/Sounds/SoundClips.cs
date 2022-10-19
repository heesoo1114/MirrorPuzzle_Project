using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundClips : MonoBehaviour
{
    public ClipListSO clipList;
    effectClips effectClip;
    bgmClips bgmClip;

    public AudioClip GetClipToEnum(Util.Effect effectName)
    {
        effectClip = clipList.effectClips.Find(x => x.effectName == effectName);

        if (effectClip == null) Debug.Log($"{effectName} Clip is can't found");
        return effectClip.clip;
    }

    public AudioClip GetClipToEnum(Util.Bgm bgmName)
    {
        bgmClip = clipList.bgmClips.Find(x => x.bgmName == bgmName);

        if (bgmClip == null) Debug.Log($"{bgmName} Clip is can't found");
        return bgmClip.clip;
    }
}