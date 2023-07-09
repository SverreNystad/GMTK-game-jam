using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIMovement
{
    public class NormalMovement : MonoBehaviour, IMovement 
    {        
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Rigidbody2D target;
        private string targetTag = "Boss";
        private Animator anim;

        private Vector2 movement;

        private bool shouldAdvance;
        [SerializeField] private int speed;
        private FightHandler fightHandler;
        void Start()
        {
            // Get myself and my target
            anim = GetComponent<Animator>();
            fightHandler = GetComponent<FightHandler>();
            this.rb = GetComponent<Rigidbody2D>();
            this.target = GameObject.FindWithTag(targetTag).GetComponent<Rigidbody2D>();
        }
        void FixedUpdate() 
        {
            DoMove();
        }

        public Vector2 GetLastDirection()
        {
            return movement;
        }

        private void DoMove()
        {
            float step = speed * Time.fixedDeltaTime;
            if (fightHandler.IsAttackOnCooldown()) step = -step;
            if (fightHandler.IsAttacking()) step = 0;
            Vector2 targetPosition = new Vector2(target.position.x, target.position.y-((1.0f/3.0f)*target.transform.localScale.y));
            Vector2 new_move = Vector2.MoveTowards(rb.position, targetPosition, step);
            this.movement = targetPosition - rb.position;
            rb.MovePosition(new_move);
            if (step != 0) {
                anim.SetBool("IsWalking", true);
                return;
            }
            anim.SetBool("IsWalking", false);
        }

        private Vector2 FindDirection() {
            // When aggressiveness is high have a larger likelihood of 
            // Vector2 movement = new
            return new Vector2(0,0);
         }

    }
}


