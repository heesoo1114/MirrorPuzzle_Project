using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class TextPanelBehaviour : PlayableBehaviour
{
    public TextPanel textPanel;

    public string textMessage;
    public bool isPlayClip;


    public override void OnPlayableCreate (Playable playable)
    {
        textPanel = null;
        isPlayClip = false;
    }

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {

        base.OnBehaviourPlay(playable, info);

        textPanel.ShowTextPanal(textMessage);
    }

}
