using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float c;
    float timer=2;
    public Transform BugParent;
    public GameObject Bug;
    public Material[] material;

    // Start is called before the first frame update
    void Start()
    {
        c = timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            c = Mathf.Lerp(10f, 6f, Difficulty.GetDifficulty());
            for (int i = 0; i < 4; i++)
            {
                int parameter = Random.Range(1, 3);
                Vector3 spawnPos = new Vector3(-22.5f + 15f * i, 0, 26.22f);
                GameObject spawnBug = Instantiate(Bug, spawnPos, Quaternion.Euler(0, 180, 0), BugParent);
                spawnBug.transform.parent = BugParent;

                if (parameter == 2)
                {
                    spawnBug.GetComponentInChildren<Renderer>().materials[0].SetColor("_Color", Color.green);
                    spawnBug.tag = "Good";
                }
            }
            timer = c;
        }
    }
}
