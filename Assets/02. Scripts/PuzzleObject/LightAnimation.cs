using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.Universal;

public class LightAnimation : MonoBehaviour
{
    new Light2D light;
    private float intensity = 0f;
    [SerializeField] [Range(0f, 2f)] private float speed = 1f;
    
    void Start()
    {
        light = GetComponent<Light2D>();
    }

    private void Update()
    {
        intensity += Time.deltaTime * speed;

        if (intensity > 1f)
        {
            speed = -speed;
            intensity = 0.95f;
        }

        if(intensity < 0f)
        {
            speed = -speed;
            intensity = 0.05f;
        }

        light.intensity = intensity;
    }
}
