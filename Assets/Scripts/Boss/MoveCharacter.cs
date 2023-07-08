using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// namespace Boss
// {
    public class MoveCharacter : MonoBehaviour
    {

        [SerializeField] private Rigidbody2D rb;
        private Vector2 movement;
        [SerializeField] private int speed;

        void Start()
        { 
           rb = GetComponent<Rigidbody2D>();
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
            movement = movementValue.Get<Vector2>();
        }

        private void OnAbilityOne() {
            Debug.Log("Ability one pressed");
        }

        private void OnAbilityTwo() {
            Debug.Log("Ability two pressed");
        }

        private void OnAbilityThree() {
            Debug.Log("Ability three pressed");
        }

        public void DoFixedMove() 
        {
            float step = speed * Time.fixedDeltaTime;
            Vector2 new_move = Vector2.MoveTowards(rb.position, rb.position + movement, step);
            rb.MovePosition(new_move);
        }
    }
// }