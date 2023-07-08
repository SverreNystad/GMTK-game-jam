using System.Collections;
using System.Collections.Generic;
using GameState;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playBtn;
    [SerializeField] private Button quitBtn;

    void Awake()
    {
        playBtn.onClick.AddListener(() => {
            GameSceneManager.LoadIntoGame();
        });
        
        quitBtn.onClick.AddListener(() => {
            Application.Quit();
        });
    }
}
