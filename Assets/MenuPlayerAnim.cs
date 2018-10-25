using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayerAnim : MonoBehaviour
{

    DisplayManager display;
    float angle = 0;
    [Space]
    public float Xspeed;
    SpriteRenderer render;
    TrailRenderer trail;
    // Use this for initialization
    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        render = GetComponent<SpriteRenderer>();
        display = GetComponent<DisplayManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }


    void MovePlayer()
    {
        Vector2 pos = transform.position;
        pos.x = Mathf.Cos(angle) * (display.RIGHT * 0.75f);
        transform.position = pos;
        float color = Mathf.Cos(angle) * -1 + .5f;
        color = Mathf.Clamp(color, 0, 1);
        render.color = new Color(color, color, color);

        Gradient trailGradient = trail.colorGradient;
        for (int i = 0; i < trailGradient.colorKeys.Length; i++)
        {
            trailGradient.colorKeys[i].color = new Color(color, color, color, 1);
        }
        trail.colorGradient = trailGradient;
        angle += Time.deltaTime * Xspeed;
    }


    public Color InvertColor(Color color)
    {
        if (new Color(color.r, color.g, color.b) == new Color(1, 1, 1))
            return new Color(0, 0, 0, color.a);
        else
            return new Color(1, 1, 1, color.a);
    }
}
