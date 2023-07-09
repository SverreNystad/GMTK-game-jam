using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/SpawnMinions")]
public class SpawnMinions : Ability
{
    [SerializeField] GameObject minionPrefab = null;
    [SerializeField] int amountOfMinionsToSpawn = 3;
    [SerializeField] float damage = 10.0f;
    private float attackMultiplier = 1.0f;
    private Transform transform;

    public override void DoOnStart(Transform target)
    {
        if (minionPrefab == null) Debug.LogWarning("The minionPrefab was not set, so will not spawn minions!");
        transform = target;
    }

    protected override void AddUpdateActions()
    {
        
    }

    protected override void DoAction(Item[] items)
    {
        if (minionPrefab == null) return;

        float newAttackMultiplier = 1.0f;
        foreach(var item in items) {
            if (item.type != EffectTypeMultiplier.DAMAGE) continue;
            newAttackMultiplier *= item.amount;
        }
        attackMultiplier = newAttackMultiplier;

        for (int i = 0; i < amountOfMinionsToSpawn; i++) {
            GameObject minion = Instantiate(minionPrefab, transform.position, Quaternion.identity);
            if (minion.GetComponent<AttackCallback>() == null) {
                Debug.LogWarning("The minion you spawned does not have an attack callback and might therefore not do damage or it might be independent of the ability!");
                continue;
            }
            minion.GetComponent<AttackCallback>().SetCallbackFunction(CollisionCallback);
        }
    }

    private void CollisionCallback(Transform colliderTransform, Transform attackerTransform) {
        if (colliderTransform.tag == transform.tag) return;
        if (colliderTransform.tag == "Weapon") Destroy(attackerTransform.gameObject);
        if (colliderTransform.GetComponent<Health>() == null) {
            Debug.LogWarning("Collided with something that did not have an health component!");
            return;
        }
        colliderTransform.GetComponent<Health>().Damage(damage * attackMultiplier);
        Destroy(attackerTransform.gameObject);
    }
}
