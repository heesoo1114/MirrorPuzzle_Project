using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class TextPanelBehaviour : PlayableBehaviour
{
    [HideInInspector]
    public TextSystem textPanel;

    public string nameText;
    public string textMessage;
    public bool isPlayClip;
    public Vector3 destPos;


    public override void OnPlayableCreate (Playable playable)
    {
        textPanel = null;
        isPlayClip = false;
    }

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {

        base.OnBehaviourPlay(playable, info);

        GameObject target;

        textPanel.ShowTextPanal(textMessage, nameText);
    }

}
