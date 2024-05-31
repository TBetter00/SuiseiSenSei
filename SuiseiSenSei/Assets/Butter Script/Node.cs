using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream


public class Node : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public List<Vector2> availableDirections { get; private set; }
=======
public class Node : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public List<Vector2> availableDirections {get; private set;}
>>>>>>> Stashed changes

    private void Start()
    {
        this.availableDirections = new List<Vector2>();
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
        CheckAvailableDirection(Vector2.up);
        CheckAvailableDirection(Vector2.down);
        CheckAvailableDirection(Vector2.left);
        CheckAvailableDirection(Vector2.right);
<<<<<<< Updated upstream

        
=======
>>>>>>> Stashed changes
    }

    private void CheckAvailableDirection(Vector2 direction)
    {
<<<<<<< Updated upstream
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();


        // Calculate center point of the node
=======

        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider == null)
        {
            Debug.LogError("boxCollider2D component is missing on the Pacmon game object.");
            
        }

        // Calculate center point of the player
>>>>>>> Stashed changes
        Vector2 center2D = (Vector2)transform.position + boxCollider.offset;

        // Convert center point to Vector3
        Vector3 center = new Vector3(center2D.x, center2D.y, transform.position.z);

        // Perform the raycast from the center point
<<<<<<< Updated upstream
        RaycastHit2D hit = Physics2D.BoxCast(center, Vector2.one * 0.5f, 0.0f, direction, 0.5f, obstacleLayer);

        // Debug ray visualization
        Debug.DrawRay(center, direction * 1.5f, Color.red, 0.1f);

        if (hit.collider == null)
        {
            this.availableDirections.Add(direction);
        }
    }
}

=======
        RaycastHit2D hit = Physics2D.BoxCast(center, Vector2.one * 0.5f, 0.0f, direction, 0.5f, this.obstacleLayer);
        
        // Debug ray visualization
        Debug.DrawRay(center, direction * 1.5f, Color.red, 0.1f);
        
        // Debug logging
        if (hit.collider != null)
        {
            Debug.Log("Hit object: " + hit.collider.name);
        }
        else
        {
            Debug.Log("No object hit.");
        }
        
    }
}
>>>>>>> Stashed changes
