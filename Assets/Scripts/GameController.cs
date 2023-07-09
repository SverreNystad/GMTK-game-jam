using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameState;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject heroPrefab;
    public GameObject[] popups;
    private int timesDefeated = 0;
    private GameObject niceBtn;
    private BossInputHandler inputHandler;

    void Start()
    {
        this.popups = GameObject.FindGameObjectsWithTag("Popup");
        this.niceBtn = GameObject.FindGameObjectWithTag("SpecificButton");
        this.inputHandler = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossInputHandler>();

        foreach (var popup in popups)
        {
            popup.SetActive(false);
        }
       niceBtn.SetActive(false);

        niceBtn.GetComponent<Button>().onClick.AddListener(() => {
            GameSceneManager.LoadIntoWaitingRoom();
        });
    }

    public void Died(Transform transformOfDied) {
        if (transformOfDied.tag == "Hero") HandleHeroDied(transformOfDied.gameObject);
        if (transformOfDied.tag == "Boss" && !transformOfDied.GetComponent<Health>().IsAlive()) HandleLoss();
    }

    private void HandleHeroDied(GameObject hero) {
        timesDefeated++;
        Destroy(hero);
        if (timesDefeated >= 3){
            HandleWin();
            return;
        };
        Instantiate(heroPrefab, -GameObject.FindGameObjectWithTag("Boss").transform.position, Quaternion.identity);
    }

    private void HandleWin() {
        foreach (var popup in popups)
        {
            popup.SetActive(true);
        }
        niceBtn.SetActive(true);

        inputHandler.canMove = false;
        inputHandler.canAttack = false;
    }

    private void HandleLoss() {
        GameSceneManager.LoadIntoWaitingRoom();
    }
}
