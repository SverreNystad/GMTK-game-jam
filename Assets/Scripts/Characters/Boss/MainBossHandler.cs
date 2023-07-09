using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBossHandler : MonoBehaviour
{
    [SerializeField] private string bossName;
    [SerializeReference] private Ability[] abilities = new Ability[3];
    [SerializeReference] private Item[] items;
    [SerializeField] private IMovement movementController;
    [SerializeField] private float speed;
    [SerializeField] private Health health;
    [SerializeField] private BossInputHandler inputHandler;

    void Awake()
    {
        this.health = GetComponent<Health>();
        this.inputHandler = GetComponent<BossInputHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(var ability in abilities) ability.DoOnStart(transform); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!health.IsAlive()){
            inputHandler.canMove = false;
            return;
        }
        foreach (var ability in abilities) ability.DoUpdate();
    }
    
    private void OnAbilityOne() {
        abilities[0].ActivateAbility(items);
    }

    private void OnAbilityTwo() {
        abilities[1].ActivateAbility(items);
    }

    private void OnAbilityThree() {
        abilities[2].ActivateAbility(items);
    }
}
