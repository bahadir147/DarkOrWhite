using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleParent : MonoBehaviour
{

    void Start()
    {
		StartCoroutine(CalculateDistance());
    }

    IEnumerator CalculateDistance()
    {
        while (true)
        {
            if (GameObject.Find("Player").transform.position.y - transform.position.y > 60)
            {
                Destroy(this.gameObject);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }


}