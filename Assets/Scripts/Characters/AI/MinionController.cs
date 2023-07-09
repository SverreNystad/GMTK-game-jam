using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MinionController : MonoBehaviour, IMovement
{
    [SerializeField] private string tagToFollow = "";
    [SerializeField] private float speed = 1.0f;
    private Vector2 lastMoveDir = Vector2.right;
    private GameObject targetToFollow = null;
    private Rigidbody2D rb;

    public Vector2 GetLastDirection()
    {
        return lastMoveDir;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (targetToFollow == null && GameObject.FindGameObjectWithTag(tagToFollow)) {
            targetToFollow = GameObject.FindGameObjectWithTag(tagToFollow);
        }
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTarget(Time.deltaTime);
    }

    private void MoveTowardsTarget(float deltaTime) {
        if (targetToFollow == null) {
            Debug.LogWarning("The minion has no target to follow");
            return;
        }
        Vector3 targetPos = targetToFollow.transform.position;
        rb.MovePosition((new Vector2(targetPos.x, targetPos.y) - rb.position) * speed * deltaTime);
    }
}
