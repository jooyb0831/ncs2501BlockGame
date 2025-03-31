using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerData
{
    public string Name = string.Empty;
    public int HighScore = 0;
}
public class StartSceneManager : MonoBehaviour
{
    private PlayerData playerData = new PlayerData();
    private string nameStr = string.Empty;
    public int score;
    [SerializeField] TMP_Text bestScoreTxt;
    [SerializeField] TMP_InputField nameInput;

    void Start()
    {
        if(nameStr==string.Empty)
        {
            bestScoreTxt.text = $"Best Score : None";
        }
        else
        {
            bestScoreTxt.text = $"Best Score : {nameStr} : {score}";
        }

    }

    public void OnInpuField()
    {
        nameInput.text = playerData.Name;
        //MainManager.Instance
    }

    public void OnStartBtnClicked()
    {
        SceneManager.LoadScene("main");
    }
}
