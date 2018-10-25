using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public Canvas myCanvas;
    public GameObject nextSceneObject;
    AsyncOperation scene;
    private bool loading = false;
    public GameObject player;
    public void NextSceneGame(int BlackOrWhite)
    {
        if (Time.timeSinceLevelLoad < .5f) return;
        if (loading) return;
        loading = true;
        Destroy(player);
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
        nextSceneObject.transform.position = myCanvas.transform.TransformPoint(pos);
        if (BlackOrWhite == 1)
            nextSceneObject.GetComponent<Image>().color = Color.black;
        else
            nextSceneObject.GetComponent<Image>().color = Color.white;
        nextSceneObject.SetActive(true);
        PlayerPrefs.SetInt("GameKey", BlackOrWhite);
        Invoke("GoScene", 0.25f);
        scene = SceneManager.LoadSceneAsync(1);
        scene.allowSceneActivation = false;
    }


    public void GoScene()
    {
        scene.allowSceneActivation = true;
    }
}
