using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBossHandler : MonoBehaviour
{
    [SerializeField] private string bossName;
    [SerializeField, SerializeReference] private Abilities[] abilities;
    [SerializeField, SerializeReference] private Items[] items;
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
        
    }
}
