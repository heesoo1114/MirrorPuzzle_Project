using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OliverAnimation : MonoBehaviour
{
    private Animator _visualAnimator;

    private void Awake()
    {
        _visualAnimator = transform.Find("VisualSprite").GetComponent<Animator>();
    }

    public void PlayAnimation(string walkType)
    {
        if (_visualAnimator == null) return;
        if (walkType == null) return;
        StopAllCoroutines();

        if (walkType.Contains("Walk"))
        {
            StartCoroutine(PlayAnimationCoroutine(walkType));
        }

        else
        {
            _visualAnimator.Play(walkType);
        }
    }

    private IEnumerator PlayAnimationCoroutine(string walkType)
    {
        while (GameManager.Inst.GameState == EGameState.Timeline)
        {
            _visualAnimator.Play(walkType);

            yield return new WaitForFixedUpdate();
        }
    }
}
