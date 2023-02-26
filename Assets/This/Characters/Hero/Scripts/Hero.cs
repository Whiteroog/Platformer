using System;
using UnityEngine;

namespace This.Characters.Hero.Scripts
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private int lives = 5;
        
        [SerializeField] private float speed = 3f;
        [SerializeField] private float jumpForce = 12f;

        [SerializeField] private SpriteRenderer spriteCharacter;
        [SerializeField] private Rigidbody2D rb;

        [SerializeField] private Animator anim;

        [SerializeField] private Vector2 offsetCircleOverlap = new Vector2(0f, 0.2f);
        [SerializeField] private float radiusCircleOverlap = 0.35f;

        private bool _isGrounded = false;

        private void FixedUpdate()
        {
            CheckGround();
        }

        private void Update()
        {
            if (Input.GetButton("Horizontal"))
            {
                Run();
            }

            if (_isGrounded && Input.GetButtonDown("Jump"))
            {
                Jump();
            }

            UpdateAnimationState();
        }

        private void UpdateAnimationState()
        {
            anim.SetBool("Run", Input.GetButton("Horizontal") && _isGrounded);
            anim.SetBool("Jump", !_isGrounded);
        }

        private void Run()
        {
            Vector3 dir = Vector3.right * Input.GetAxis("Horizontal");

            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

            spriteCharacter.flipX = dir.x > 0f;
        }

        private void Jump()
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        private void CheckGround()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll((Vector2)transform.position + offsetCircleOverlap, radiusCircleOverlap);
            _isGrounded = colliders.Length > 1; // with considering character collider
        }
    }
}