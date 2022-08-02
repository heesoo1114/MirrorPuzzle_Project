using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBrotherSound : AudioPlayer
{
    [SerializeField]
    private AudioClip   dragDropSound,
                        reload_Play_Sound,
                        gunShootSound;
    public void DragDropBullet()
    {
        PlayClip(dragDropSound);
    }
    public void BearGameStart()
    {
        PlayClip(reload_Play_Sound);
    }
    public void GunShootSound()
    {
        PlayClip(gunShootSound);
    }

}
