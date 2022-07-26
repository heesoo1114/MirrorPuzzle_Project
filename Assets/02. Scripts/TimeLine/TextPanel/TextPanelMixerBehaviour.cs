using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TextPanelMixerBehaviour : PlayableBehaviour
{
    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextPanel trackBinding = playerData as TextPanel;

        if (!trackBinding)
            return;


        int inputCount = playable.GetInputCount();

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<TextPanelBehaviour> inputPlayable = (ScriptPlayable<TextPanelBehaviour>)playable.GetInput(i);
            TextPanelBehaviour input = inputPlayable.GetBehaviour();

            if(input.textPanel == null)
            input.textPanel = trackBinding;
            // Use the above variables to process each frame of this playable.
        }
    }

}
