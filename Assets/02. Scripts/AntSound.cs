using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AntSound : AudioPlayer
{
    [SerializeField] private AudioClip antDieClip; //¹ú·¹ Á×À»°æ¿ì
    [SerializeField] private AudioClip antStepClip; //¹ú·¹ Á×À»°æ¿ì

    public void BugDieSound()
    {
        PlayClip(antDieClip);
    }

    public void BugStepSound()
    {
        PlayClip(antStepClip);
    }
}
