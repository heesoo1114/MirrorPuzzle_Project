using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAddSound : AudioPlayer
{
    public AudioClip addSound = null;

    public void PlayAddSound()
    {
        PlayClip(addSound);
    }
}
