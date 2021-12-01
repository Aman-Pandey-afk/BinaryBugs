using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSlider : MonoBehaviour
{
    private float openSpeed = 2;
    private float closeSpeed = 0.8f;
    private bool[] open;
    private float size;
    private int num;

    public Transform Gates;
    GameObject[] gameObjects;

    public AudioMangaer audioManager;

    // Start is called before the first frame update
    void Start()
    {
        open = new bool[4];

        gameObjects = new GameObject[Gates.childCount];
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i] = Gates.GetChild(i).gameObject;
        }
        size = gameObjects[1].transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        num = UI.num;
        if (num / 8 == 1)
        {
            open[0] = true; audioManager.Play("GateSlideOut"); num -= 8;
        }
        if (num / 4 == 1)
        {
            open[1] = true; audioManager.Play("GateSlideOut"); num -= 4;
        }
        if (num / 2 == 1)
        {
            open[2] = true; audioManager.Play("GateSlideOut"); num -= 2;
        }
        if (num == 1)
        {
            open[3] = true; audioManager.Play("GateSlideOut"); num -= 1;
        }
        Slide(gameObjects[0], ref open[0]);
        Slide(gameObjects[1], ref open[1]);
        Slide(gameObjects[2], ref open[2]);
        Slide(gameObjects[3], ref open[3]);

    }

    void Slide(GameObject obj,ref bool op)
    {
        if (op)
        {

            if (obj.transform.localScale.x > .1f)
            {
                if (op) obj.transform.localScale = new Vector3(Mathf.Lerp(obj.transform.localScale.x, 0f, openSpeed * Time.deltaTime), obj.transform.localScale.y, obj.transform.localScale.z);
            }
            else { op = false; audioManager.Play("GateSlideIn"); }
            }
        else if (transform.localScale.x < size)
        {
            obj.transform.localScale = new Vector3(Mathf.Lerp(obj.transform.localScale.x, size + 0.1f, closeSpeed * Time.deltaTime), obj.transform.localScale.y, obj.transform.localScale.z);
        }
    }
}
