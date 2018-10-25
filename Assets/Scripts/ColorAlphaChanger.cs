using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAlphaChanger : MonoBehaviour
{

    private SpriteRenderer render;
    public float alpha = 51.0F;


    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        render.color = new Color(render.color.r, render.color.g, render.color.b, alpha / 255);
    }
}
