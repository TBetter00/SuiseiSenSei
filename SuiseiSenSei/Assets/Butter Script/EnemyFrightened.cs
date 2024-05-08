using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrightened : EnemyBehavior
{
    private Animator animator; // Reference to the Animator component

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        this.enemy.scatter.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && this.enabled)
        {
            Vector2 direction = Vector2.zero;
            float maxDistance = float.MinValue;

            foreach (Vector2 availableDirection in node.availableDirections)
            {
                Vector3 newPosition = this.transform.position + new Vector3(availableDirection.x, availableDirection.y, 0.0f);
                float distance = (this.enemy.target.position - newPosition).sqrMagnitude;

                if (distance > maxDistance)
                {
                    direction = availableDirection;
                    maxDistance = distance;
                }
            }

            // Set direction for movement
            this.enemy.movement.SetDirection(direction);

            // Trigger animation based on movement direction
            if (direction == Vector2.up)
            {
                animator.Play("blinky up");
            }
            else if (direction == Vector2.down)
            {
                animator.Play("blinky down");
            }
            else if (direction == Vector2.left)
            {
                animator.Play("blinky left");
            }
            else if (direction == Vector2.right)
            {
                animator.Play("blinky right");
            }
        }
    }
}