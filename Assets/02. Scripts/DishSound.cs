using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DishSound : AudioPlayer
{
    [SerializeField] private AudioClip bubbleClip;
    [SerializeField] private AudioClip dishClip;

    public void BubbleSound() 
    {
        PlayClipWithRandnessPitch(bubbleClip); 
    }

    public void DishClearSound()
    {
        PlayClip(dishClip);
    }
}
