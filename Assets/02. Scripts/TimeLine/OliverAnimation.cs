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

        // 위치 변경
        GameManager.Inst.gameState = EGameState.Timeline;
        int hash = Animator.StringToHash(walkType);

        if (walkType.Contains("Walk"))
        {
            StartCoroutine(PlayAnimationCoroutine(hash));
        }

        else
        {
            _visualAnimator.Play(hash);
        }
    }

    private IEnumerator PlayAnimationCoroutine(int hash)
    {
        while (GameManager.Inst.gameState == EGameState.Timeline)
        {
            _visualAnimator.Play(hash);

            yield return new WaitForFixedUpdate();
        }
    }
}
