using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class effectClips
{
    public Util.Effect effectName;
    public AudioClip clip;
}

[System.Serializable]
public class bgmClips
{
    public Util.Bgm bgmName;
    public AudioClip clip;
}

[CreateAssetMenu(menuName ="SO/ClipList")]
public class ClipListSO : ScriptableObject
{
    public List<effectClips> effectClips = new List<effectClips>();
    public List<bgmClips> bgmClips = new List<bgmClips>();
}
