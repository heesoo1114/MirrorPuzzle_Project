using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AntSound : AudioPlayer
{
    [SerializeField] private AudioClip antDieClip; //���� �������
    [SerializeField] private AudioClip antStepClip; //���� �������

    public void BugDieSound()
    {
        PlayClip(antDieClip);
    }

    public void BugStepSound()
    {
        PlayClip(antStepClip);
    }
}
