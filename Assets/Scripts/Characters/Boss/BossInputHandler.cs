using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class BossInputHandler : MonoBehaviour, IMovement
{

    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 lastMovementDir = new Vector2(1.0f, 0.0f);
    [SerializeField] private int speed;
    public Animator animator;
    public bool canMove {get; set;}
    public bool canAttack {get; set;}
    private bool isMoving;

    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "WaitingRoom"){
            canMove = true;
            canAttack = false;
        }
        else if (scene.name == "GameMap"){
            canMove = true;
            canAttack = true;
        }
    }

    void Update()
    {
        if (!isMoving){
            animator.SetBool("IsWalkingForward", false);
            animator.SetBool("IsWalkingSideways", false);
        }
    }

    void FixedUpdate() 
    {
        DoFixedMove();
    }

    /// <summary>
    /// Move the character to the target position
    /// The method takes the transform of the wanted character and the target position
    /// </summary>
    private void OnMove(InputValue movementValue)
    {
        if (canMove) {
            movement = movementValue.Get<Vector2>();
            if (movement == new Vector2(0.0f, 0.0f)){
                isMoving = false;
                return;
            }
            isMoving = true;

            if (movement.y != 0){
                animator.SetBool("IsWalkingSideways", false);
                animator.SetBool("IsWalkingForward", true);
            }
            else if (movement.x != 0){
                animator.SetBool("IsWalkingForward", false);
                animator.SetBool("IsWalkingSideways", true);
            }

            lastMovementDir = movement;
        }
    }

    public void DoFixedMove() 
    {
        float step = speed * Time.fixedDeltaTime;
        Vector2 new_move = Vector2.MoveTowards(rb.position, rb.position + movement, step);
        rb.MovePosition(new_move);
    }

    public Vector2 GetLastDirection() {
        return lastMovementDir;
    }
}
