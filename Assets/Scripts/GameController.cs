using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameState;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject heroPrefab;
    private int timesDefeated = 0;

    public void Died(Transform transformOfDied) {
        if (transformOfDied.tag == "Hero") HandleHeroDied(transformOfDied.gameObject);
        if (transformOfDied.tag == "Boss" && !transformOfDied.GetComponent<Health>().IsAlive()) HandleLoss();
    }

    private void HandleHeroDied(GameObject hero) {
        timesDefeated++;
        Destroy(hero);
        if (timesDefeated >= 3) HandleWin();
        Instantiate(heroPrefab, -GameObject.FindGameObjectWithTag("Boss").transform.position, Quaternion.identity);
    }

    private void HandleWin() {
        GameSceneManager.LoadIntoWaitingRoom();
    }

    private void HandleLoss() {
        GameSceneManager.LoadIntoWaitingRoom();
    }
}
