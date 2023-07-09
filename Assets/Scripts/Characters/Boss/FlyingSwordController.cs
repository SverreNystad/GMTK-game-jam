using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FlyingSwordController : MonoBehaviour, IMovement
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float spinDeegrees = 10.0f;
    private Vector2 direction = default;

    public Vector2 GetLastDirection()
    {
        return direction;
    }

    public void SetInitialDirection(Vector2 dir) {
        if (direction != default) {
            Debug.LogWarning("The direction has already been set, and you cannot change it after it has been set.");
            return;
        }
        direction = dir;
    }

    void FixedUpdate()
    {
        if (direction == default) {
            Debug.LogWarning("There was no direction set for the flying sword!");
            return;
        }
        Vector2 newDir = direction * speed * Time.fixedDeltaTime;
        transform.position += new Vector3(newDir.x, newDir.y, 0.0f);
        transform.eulerAngles += new Vector3(0.0f, 0.0f, spinDeegrees*Time.fixedDeltaTime);
    }
}
