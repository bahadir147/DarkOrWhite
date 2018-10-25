using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangerReverter : MonoBehaviour {

    public SpriteRenderer circlerender;
    public TextMesh textColor;
	// Use this for initialization
	void Start () {
		
	}
    private void OnEnable()
    {
       if(ObstacleManager.Instance.revertColor)
        {
        }
        else
        {
            circlerender.color = ObstacleManager.Instance.InvertColor(circlerender.color);
            textColor.color = ObstacleManager.Instance.InvertColor(textColor.color);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
