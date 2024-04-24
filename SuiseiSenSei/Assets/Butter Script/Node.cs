

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

        // Start the coroutine to continuously check for obstacles
        StartCoroutine(CheckAvailableDirectionsRoutine());
    }

    private IEnumerator CheckAvailableDirectionsRoutine()
    {
        while (true)
        {
            CheckAvailableDirection(Vector2.up);
            CheckAvailableDirection(Vector2.down);
            CheckAvailableDirection(Vector2.left);
            CheckAvailableDirection(Vector2.right);

            // Wait for a short period before checking again
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void CheckAvailableDirection(Vector2 direction)
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider == null)
        {
            Debug.LogError("BoxCollider2D component is missing on the Node game object.");
            return;
        }

        // Calculate center point of the node
        Vector2 center2D = (Vector2)transform.position + boxCollider.offset;

        // Convert center point to Vector3
        Vector3 center = new Vector3(center2D.x, center2D.y, transform.position.z);

        // Perform the raycast from the center point
        RaycastHit2D hit = Physics2D.BoxCast(center, Vector2.one * 0.5f, 0.0f, direction, 0.5f, obstacleLayer);

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

