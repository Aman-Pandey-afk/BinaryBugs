using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public GameObject GameLoseUI;
    public void OnMenuClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void OnReplay()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
