using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartingSceneLoad : MonoBehaviour {

    public Button startButton;
    public Button quitButton;
    public Animator animator;
    int LevelToLoad;
    
    // Use this for initialization
	void Start () {
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
	}
	
    void QuitGame()
    {
        Application.Quit();
    }

	void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
