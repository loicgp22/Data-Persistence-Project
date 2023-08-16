using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public string inputName;
    public GameObject inputField;
    public Button startButton;

    public Text BestScoreText;

    private void Start()
    {
        BestScoreText.text = "Best Score: " + MainManager.Instance.playerNameBest + " : " + MainManager.Instance.scoreBest;
        startButton.interactable = false;
    }

    public void ClearData()
    {
        MainManager.Instance.ClearData();
        BestScoreText.text = "Best Score: " + MainManager.Instance.playerNameBest + " : " + MainManager.Instance.scoreBest;
    }

    public void StoreName()
    {
        inputName = inputField.GetComponent<Text>().text;
        NewNameSelected(inputName);
        MainManager.Instance.SaveAllData();
    }
    
    public void NewNameSelected(string playerName)
    {
        // add code here to handle when a name is selected
        Debug.Log("name:" + playerName);
        MainManager.Instance.playerName = playerName;
        startButton.interactable = true;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        MainManager.Instance.SaveAllData();

        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
        }
    }
}
