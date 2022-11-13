using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibrarySound : AudioPlayer
{
    [SerializeField]
    private AudioClip rightAnswerSound,
                      notAnswerSound;

    public void RightAnswer()
    {
        PlayClip(rightAnswerSound);
    }
    public void NotAnswer()
    {
        PlayClip(notAnswerSound);
    }

}

