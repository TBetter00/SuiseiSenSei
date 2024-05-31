using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScatter : EnemyBehavior
{
<<<<<<< Updated upstream
    public Animator animator;

    private void Start()
    {
        // Get reference to the Animator component
        //animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        Debug.Log("Scatter disabled");
        GetComponent<Enemy>().HandleStateOnDisable(this);
    }

=======
>>>>>>> Stashed changes
    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && this.enabled && !this.enemy.frightened.enabled)
        {
            int index = Random.Range(0, node.availableDirections.Count);

            if (node.availableDirections[index] == -this.enemy.movement.direction && node.availableDirections.Count > 1)
            {
                index++;

<<<<<<< Updated upstream
                if (index >= node.availableDirections.Count)
                {
=======
                if (index >= node.availableDirections.Count){
>>>>>>> Stashed changes
                    index = 0;
                }
            }

<<<<<<< Updated upstream
            // Set direction
            Vector2 direction = node.availableDirections[index];
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
=======
            this.enemy.movement.SetDirection(node.availableDirections[index]);
>>>>>>> Stashed changes
        }
    }
}
