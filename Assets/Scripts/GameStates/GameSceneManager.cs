using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameState
{
    public class GameSceneManager : MonoBehaviour
    {
        public static void LoadIntoMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public static void LoadIntoGame()
        {
            SceneManager.LoadScene("GameMap");
        }

        public static void LoadIntoScoreBoard()
        {
            SceneManager.LoadScene("ScoreBoard");
        }

        public static void LoadIntoWaitingRoom()
        {
            SceneManager.LoadScene("WaitingRoom");
        }
    }

}