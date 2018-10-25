using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public GameObject fx_Dead;
    public GameObject fx_ColorChange;
    GameObject GameManagerObj;


    Rigidbody2D rb;

    float angle = 0;

    [Space]
    public float Xspeed;

    public int YaccelerationForce;
    public int YdecelerationForce;
    public int YspeedMax;
    public float hueValue;
    bool isDead = false;

    void Start()
    {
        GameManagerObj = GameObject.Find("GameManager");
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (isDead) return;
        MovePlayer();
    }


    void MovePlayer()
    {

        Vector2 pos = transform.position;
        pos.x = Mathf.Cos(angle) * (GameManagerObj.GetComponent<DisplayManager>().RIGHT * 0.9f);
        pos.y += 0.002f;
        transform.position = pos;
        angle += Time.deltaTime * Xspeed;


        if (Input.GetMouseButton(0))
        {
            if (rb.velocity.y < YspeedMax)
            {
                rb.AddForce(new Vector2(0, YaccelerationForce));
            }
        }
        else
        {
            if (rb.velocity.y > 0)
            {
                rb.AddForce(new Vector2(0, -YdecelerationForce));
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Item_ColorChange")
        {
            Destroy(Instantiate(fx_ColorChange, other.gameObject.transform.position, Quaternion.identity), 0.5f);
            Destroy(other.gameObject.transform.parent.gameObject);
            //SetBackgroundColor();
            CameraBGManager.Instance.SetStartColor();
            GameManagerObj.GetComponent<GameManager>().addScore();


        }

        if (other.gameObject.tag == "Obstacle" && isDead == false)
        {
            isDead = true;

            Destroy(Instantiate(fx_Dead, transform.position, Quaternion.identity), 0.5f);
            StopPlayer();

        }
    }



    void StopPlayer()
    {
        SceneManager.LoadScene(0);
        rb.velocity = new Vector2(0, 0);
        rb.isKinematic = true;
    }

}
