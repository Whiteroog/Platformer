using System;
using This.Characters.Scripts;
using UnityEngine;

namespace This.Characters.Enemy.Scripts
{
    public class Enemy : Entity
    {
        [SerializeField] private float speed = 3f;
        
        [SerializeField] private Vector2 offsetOverlapCapsule = new Vector2(0.27f, 0.02f);
        [SerializeField] private Vector2 sizeOverlapCapsule = new Vector2(0.63f, 0.55f);

        [SerializeField] private SpriteRenderer spriteEnemy;
        
        private Vector3 _directionMove = Vector3.right;

        private void Update()
        {
            Move();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject == Hero.Scripts.Hero.Instance.gameObject)
            {
                Hero.Scripts.Hero.Instance.GetDamage();
            }
        }

        private void Move()
        {
            Collider2D[] colliders = Physics2D.OverlapCapsuleAll((Vector2)transform.position + offsetOverlapCapsule,
                sizeOverlapCapsule, CapsuleDirection2D.Horizontal, 0f);

            if (colliders.Length > 1)
                _directionMove *= -1f;

            transform.position =
                Vector3.MoveTowards(transform.position, transform.position + _directionMove, speed * Time.deltaTime);
            
            spriteEnemy.flipX = _directionMove.x > 0f;
        }
    }
}
