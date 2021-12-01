using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public static int num;
    public static int score = 0;
    public GameObject GameLoseUI;
    public TextMeshProUGUI SecondsToWin;
    public InputField inputField;
    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
        inputField.ActivateInputField();
    }

    private void Update()
    {
        text.text = score.ToString();
        if(BugController.redBug>=10)
        {
            OnGameOver(GameLoseUI);
        }
    }
    private void LateUpdate()
    {
        num = 0;
    }


    public void ReadString(string s)
    {
        num = int.Parse(s);
    }
    void OnGameOver(GameObject gameOverUI)
    {
        gameOverUI.SetActive(true);
        SecondsToWin.text = "Your Score: " + score.ToString();
    }
}
