using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIMovement
{
    public class CowardMovement : MonoBehaviour, IMovement 
    {        
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Rigidbody2D target;
        private string targetTag = "Boss";

        private Vector2 movement;
        [SerializeField] private int speed;
        void Start()
        {
            // Get myself and my target
            this.rb = GetComponent<Rigidbody2D>();
            this.target = GameObject.FindWithTag(targetTag).GetComponent<Rigidbody2D>();
        }
        void FixedUpdate() 
        {
            // TODO: Need to move towards target
            DoMove();

        }

        public Vector2 GetLastDirection()
        {
            return movement;
        }



        private void DoMove()
        {
            float step = speed * Time.fixedDeltaTime;
            Vector2 new_move = Vector2.MoveTowards(target.position, rb.position, step);
            this.movement = new_move;
            rb.MovePosition(new_move);
        }


    }
}


