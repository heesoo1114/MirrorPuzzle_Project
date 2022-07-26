using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentStepSound : AudioPlayer
{
    [SerializeField] private AudioClip _stepClip;

    public void PlayStepSound()
    {
        PlayClipWithRandnessPitch(_stepClip);
    }
}
