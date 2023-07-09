using System.Collections;
using System.Collections.Generic;
using GameState;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playBtn;
    [SerializeField] private Button quitBtn;
    [SerializeField] private Button soundsGoodBtn;
    public GameObject[] popups;

    void Start()
    {
        playBtn.onClick.AddListener(() => {
            popup();
        });
        
        quitBtn.onClick.AddListener(() => {
            Application.Quit();
        });

        soundsGoodBtn.onClick.AddListener(() => {
            GameSceneManager.LoadIntoGame();
        });

        popups = GameObject.FindGameObjectsWithTag("Popup");
        foreach (var popup in popups)
        {
            popup.SetActive(false);
        }
    }

    void popup()
    {
        foreach (var popup in popups)
        {
            popup.SetActive(true);
        }
    }
}
