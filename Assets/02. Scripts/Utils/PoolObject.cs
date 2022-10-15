using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public SoundPlayer sound;

    void Start()
    {
        PoolManager.Instance = new PoolManager(transform);
        PoolManager.Instance.CreatePool(sound);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            SoundManager.Inst.BgmStart(Util.Bgm.Main);
        if (Input.GetKeyDown(KeyCode.X))
            SoundManager.Inst.EffectStart(Util.Effect.GameClear);
        if (Input.GetKeyDown(KeyCode.C))
            SoundManager.Inst.BgmStop(Util.Bgm.Main);

        if (Input.GetKeyDown(KeyCode.F))
        {
            LetterUI.OpenLetter("���� ������.\n����������.\n�׸��� ������.");
        }
    }
}
