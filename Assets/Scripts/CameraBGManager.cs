using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBGManager : MonoBehaviour
{
    private static CameraBGManager instance;
    public static CameraBGManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<CameraBGManager>();

            }
            return CameraBGManager.instance;
        }
    }

    public Color startColor;
    public Color targetColor;

    public float changerSpeed = .5f;
    public float targetSpeed = 1f;

    public Camera camera;
    // Use this for initialization
    void Start()
    {
        camera = GetComponent<Camera>();
        camera.backgroundColor = startColor;
    }

    private void Update()
    {
        if (Time.timeSinceLevelLoad < .5f) return;
        camera.backgroundColor = Color.Lerp(camera.backgroundColor, targetColor, changerSpeed * Time.deltaTime);
        changerSpeed = Mathf.Lerp(changerSpeed, targetSpeed, .007f * Time.deltaTime);
        
    }

    public void SetStartColor()
    {
        camera.backgroundColor = startColor;
    }
}
