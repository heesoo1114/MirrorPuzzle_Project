using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ladder : MonoBehaviour
{
    [SerializeField] private GameObject ToGarretWarpPoint;
    private SpriteRenderer spriteRenderer;
    SpriteRenderer spr;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spr = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnEnable()
    {
        StartCoroutine(FadeCoroutine());
        ToGarretWarpPoint.gameObject.SetActive(true);
    }

    IEnumerator FadeCoroutine()
    {
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Color fade = new Color(1, 1, 1, fadeCount);
            spriteRenderer.color = fade;
            spr.color = fade;
        }
    }
}
