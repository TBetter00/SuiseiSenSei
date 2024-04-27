using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrightened : EnemyBehavior
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && this.enabled && !this.enemy.frightened.enabled)
        {
            // Debug.Log("Chase mode");
            Vector2 direction = Vector2.zero;
            float maxDistance = float.MinValue;

            foreach (Vector2 availableDirections in node.availableDirections)
            {
                Vector3 newPosition = this.transform.position + new Vector3(availableDirections.x, availableDirections.y, 0.0f);
                float distance = (this.enemy.target.position - newPosition).sqrMagnitude;

                if (distance > maxDistance)
                {
                    direction = availableDirections;
                    maxDistance = distance;
                }
            }

            this.enemy.movement.SetDirection(direction);
        }
    }
}