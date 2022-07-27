using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class TextPanelClip : PlayableAsset, ITimelineClipAsset
{
    public TextPanelBehaviour template = new TextPanelBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.All; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<TextPanelBehaviour>.Create (graph, template);
        TextPanelBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
