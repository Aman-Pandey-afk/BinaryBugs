using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugController : MonoBehaviour
{
    float speed;
    Rigidbody myRigidBody;

    public static int redBug=0;

    AudioMangaer audioMangaer;

    // Start is called before the first frame update
    void Start()
    {
        speed = Mathf.Lerp(8f, 12f, Difficulty.GetDifficulty());
        myRigidBody = GetComponent<Rigidbody>();
        audioMangaer = FindObjectOfType<AudioMangaer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(myRigidBody.transform.position.z>-25) myRigidBody.MovePosition(transform.position + speed*Time.deltaTime*Vector3.back);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Finish")
        {
            if (gameObject.tag == "Good") UI.score += 1;
            else { UI.score -= 1; redBug += 1; }
            audioMangaer.Play("BugEnd");
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Gate")
        {
            Destroy(gameObject);
        }
    }
}
