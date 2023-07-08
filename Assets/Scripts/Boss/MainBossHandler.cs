using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBossHandler : MonoBehaviour
{
    [SerializeField] private string bossName;
    [SerializeReference] private Ability[] abilities; // 
    [SerializeReference] private Item[] items;
    [SerializeField] private int health;
    [SerializeField] private MoveCharacter movementController;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var ability in abilities) ability.DoUpdate();
    }
}
