using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public float speed = 0.8f;
    public float speedMultiplier = 1.0f;

    public Vector2 initialDirection;
    public LayerMask obstacleLayer;
    public new Rigidbody2D rigidbody {get; private set; }
    public Vector2 direction { get; private set;}
    public Vector2 nextDirection {get; private set; }
    public Vector3 startingPosition {get; private set; }

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
        this.startingPosition = this.transform.position;
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.speedMultiplier = 1.0f;
        this.direction = this.initialDirection;
        this.nextDirection = Vector2.zero;
        this.transform.position = this.startingPosition;
        this.rigidbody.isKinematic = false;
        this.enabled = true;
    }

    private void Update()
    {
        if (this.nextDirection != Vector2.zero){
            SetDirection(this.nextDirection);
        }
    }



    private void FixedUpdate()
    {
        Vector2 position =  this.rigidbody.position;
        Vector2 translation = this.direction * this.speed * this.speedMultiplier;
        this.rigidbody.MovePosition(position + translation);
    }

    public void SetDirection(Vector2 direction, bool forced = false)
    {
        if (forced || !Occupied(direction))
        {
            this.direction = direction;
            this.nextDirection = Vector2.zero;

        }
        else
        {
            this.nextDirection = direction;
        }
    }

    public bool Occupied(Vector2 direction)
    {
        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
        if (circleCollider == null)
        {
            Debug.LogError("circleCollider2D component is missing on the Pacmon game object.");
            return false;
        }

        // Calculate center point of the player
        Vector2 center2D = (Vector2)transform.position + circleCollider.offset;

        // Convert center point to Vector3
        Vector3 center = new Vector3(center2D.x, center2D.y, transform.position.z);

        // Perform the raycast from the center point
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
        
        return hit.collider != null;
    }
}
