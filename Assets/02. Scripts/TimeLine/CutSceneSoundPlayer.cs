using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneSoundPlayer : MonoBehaviour
{
    public void BgmMainStop()
    {
        SoundManager.Inst.BgmStop(Util.Bgm.Main);
    }

    public void BgmMainStart()
    {
        SoundManager.Inst.BgmStart(Util.Bgm.Main);
    }

    public void BgmMirrorWorldStart()
    {
        SoundManager.Inst.BgmStart(Util.Bgm.MirrorWorld);
    }

    public void BgmMirrorWorldStop()
    {
        SoundManager.Inst.BgmStop(Util.Bgm.MirrorWorld);
    }

    public void BgmDramadicStart()
    {
        SoundManager.Inst.BgmStart(Util.Bgm.Dramadic);
    }

    public void BgmDramadicStop()
    {
        SoundManager.Inst.BgmStop(Util.Bgm.Dramadic);
    }

    public void BgmFrozenWinterStart()
    {
        SoundManager.Inst.BgmStart(Util.Bgm.FrozenWinter);
    }

    public void BgmFrozenWinterStop()
    {
        SoundManager.Inst.BgmStop(Util.Bgm.FrozenWinter);
    }

    public void BgmHopeStart()
    {
        SoundManager.Inst.BgmStart(Util.Bgm.Hope);
    }

    public void BgmHopeStop()
    {
        SoundManager.Inst.BgmStop(Util.Bgm.Hope);
    }

    public void BgmSimilarMainStart()
    {
        SoundManager.Inst.BgmStart(Util.Bgm.SimilarMain);
    }

    public void BgmSimilarMainStop()
    {
        SoundManager.Inst.BgmStop(Util.Bgm.SimilarMain);
    }
}

