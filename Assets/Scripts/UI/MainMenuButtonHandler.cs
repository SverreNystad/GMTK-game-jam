using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtonHandler : MonoBehaviour
{
    [SerializeField] private Button playGameBtn;
    [SerializeField] private Button scoreBoardBtn;
    [SerializeField] private Button exitBtn;

    // Start is called before the first frame update
    void Awake()
    {
        playGameBtn.onClick.AddListener(() => GameSceneManager.LoadIntoGame());
        scoreBoardBtn.onClick.AddListener(() => GameSceneManager.LoadIntoScoreBoard());
        exitBtn.onClick.AddListener(() => {
            Debug.Log("Quitting game"); 
            Application.Quit();
    });
    }
}
