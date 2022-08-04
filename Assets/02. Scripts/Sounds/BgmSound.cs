using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmSound : AudioPlayer
{
    [SerializeField] private AudioClip activeWorldBgm,
                                       mirrorWorldBgm;
        
    public void ActiveWorldBgm()
    {
        PlayClip(activeWorldBgm);
    }
    public void MirrorWorldBgm()
    {
        PlayClip(mirrorWorldBgm);
    }
}
