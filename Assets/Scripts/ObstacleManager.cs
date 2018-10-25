

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    private static ObstacleManager instance;
    public static ObstacleManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<ObstacleManager>();

            }
            return ObstacleManager.instance;
        }
    }



    public GameObject PlyerObj;
    public GameObject[] Obstacles;
    private int ObstacleCount;

    int ObstacleIndex = 0;
    int DistanceToNext = 52;

    GameObject FirstOne;
    GameObject SecondOne;

    int playerPositionIndex = -1;

    [SerializeField]
    public List<SpriteRenderer> allSpirtes = new List<SpriteRenderer>();


    public bool revertColor = false;

    void Start()
    {
        InstantiateObstacle();
    }

    void Update()
    {
        if (playerPositionIndex != (int)PlyerObj.transform.position.y / 25)
        {
            InstantiateObstacle();
            playerPositionIndex = (int)PlyerObj.transform.position.y / 25;
        }
    }

    public Color InvertColor(Color color)
    {
        if (new Color(color.r, color.g, color.b) == new Color(1, 1, 1))
            return new Color(0, 0, 0, color.a);
        else
            return new Color(1, 1, 1, color.a);
    }

    public void InstantiateObstacle()
    {
        ObstacleCount = Obstacles.Length;
        int FirstObstacleNumber = Random.Range(0, ObstacleCount);
        GameObject NewObs = Instantiate(Obstacles[FirstObstacleNumber], new Vector3(0, ObstacleIndex * DistanceToNext), Quaternion.identity);
        NewObs.transform.SetParent(transform);
        ObstacleIndex++;
        if (revertColor)
        {
            allSpirtes = FindObjectsOfType<SpriteRenderer>().ToList();
            RefreshAllColor();
        }
    }





    void RefreshAllColor()
    {
        foreach (var item in allSpirtes)
        {
            ColorSetting setting = item.GetComponent<ColorSetting>();
            if (setting == null)
            {
                var newSet = item.gameObject.AddComponent<ColorSetting>();
                newSet.colorSet = true;
                item.color = InvertColor(item.color);
            }
            else
            {
                if (!setting.colorSet)
                {
                    setting.colorSet = true;
                    item.color = InvertColor(item.color);
                }
            }
        }
    }









}