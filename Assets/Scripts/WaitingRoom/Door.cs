using System.Collections;
using System.Collections.Generic;
using GameState;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{

    public GameObject[] popups;
    [SerializeField] private BossInputHandler inputHandler;
    [SerializeField] private Button yesBtn;
    [SerializeField] private Button noBtn;

    // Start is called before the first frame update
    void Start()
    {
        this.inputHandler = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossInputHandler>();

        popups = GameObject.FindGameObjectsWithTag("Popup");
        foreach (var popup in popups)
        {
            popup.SetActive(false);
        }

        yesBtn.onClick.AddListener(() => {
            inputHandler.canMove = true;
            GameSceneManager.LoadIntoGame();
        });
        noBtn.onClick.AddListener(() => {
            inputHandler.canMove = true;
            foreach (var popup in popups)
            {
                popup.SetActive(false);
            }
        });
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        inputHandler.animator.SetBool("IsWalkingForward", false);
        inputHandler.animator.SetBool("IsWalkingSideways", false);
        inputHandler.canMove = false;
        foreach (var popup in popups)
        {
            popup.SetActive(true);
        }
    }
}
