using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(0f, 0.5f, 1f)]
[TrackClipType(typeof(TextPanelClip))]
[TrackBindingType(typeof(TextPanel))]
public class TextPanelTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<TextPanelMixerBehaviour>.Create (graph, inputCount);
    }

}
