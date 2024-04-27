using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Node : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public List<Vector2> availableDirections { get; private set; }

    private void Start()
    {
        this.availableDirections = new List<Vector2>();
        CheckAvailableDirection(Vector2.up);
        CheckAvailableDirection(Vector2.down);
        CheckAvailableDirection(Vector2.left);
        CheckAvailableDirection(Vector2.right);

        
    }

    private void CheckAvailableDirection(Vector2 direction)
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();


        // Calculate center point of the node
        Vector2 center2D = (Vector2)transform.position + boxCollider.offset;

        // Convert center point to Vector3
        Vector3 center = new Vector3(center2D.x, center2D.y, transform.position.z);

        // Perform the raycast from the center point
        RaycastHit2D hit = Physics2D.BoxCast(center, Vector2.one * 0.5f, 0.0f, direction, 0.5f, obstacleLayer);

        // Debug ray visualization
        Debug.DrawRay(center, direction * 1.5f, Color.red, 0.1f);

        if (hit.collider == null)
        {
            this.availableDirections.Add(direction);
        }
    }
}

