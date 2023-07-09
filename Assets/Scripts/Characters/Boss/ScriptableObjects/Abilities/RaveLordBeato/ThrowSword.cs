using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/ThrowSword")]
public class ThrowSword : Ability
{
    [SerializeField] private GameObject swordPrefab;
    [SerializeField] private float damage = 10.0f;
    private float attackMultiplier = 1.0f;
    private Transform transform;

    public override void DoOnStart(Transform target)
    {
        transform = target;
        if (swordPrefab == null) Debug.LogWarning("The sword prefab was not set, so will not spawn sword on ability usage!");
    }

    protected override void AddUpdateActions()
    {

    }

    protected override void DoAction(Item[] items)
    {
        if (swordPrefab == null) return;

        float newAttackMultiplier = 1.0f;
        foreach(var item in items) {
            if (item.type != EffectTypeMultiplier.DAMAGE) continue;
            newAttackMultiplier *= item.amount;
        }
        attackMultiplier = newAttackMultiplier;

        GameObject sword = Instantiate(swordPrefab, transform.parent.position, Quaternion.identity);
        AttackCallback callback = sword.GetComponent<AttackCallback>();
        if (callback == null) return;
        callback.SetCallbackFunction(DoDamage);
        FlyingSwordController controller = sword.GetComponent<FlyingSwordController>();
        IMovement movementController = transform.GetComponent<IMovement>();
        if (controller == null || movementController == null) return;
        controller.SetInitialDirection(movementController.GetLastDirection());
    }

    private void DoDamage(Transform collidee, Transform attacker) {
        if (collidee.tag == transform.parent.tag) return;
        else if (collidee.tag == "World") Destroy(attacker);
        else if (collidee.tag != "Hero") return;
        if (collidee.GetComponent<Health>() == null) {
            Debug.LogWarning("Collided with something that did not have an health component!");
            return;
        }
        collidee.GetComponent<Health>().Damage(damage * attackMultiplier);
        Destroy(attacker);
    }
}
