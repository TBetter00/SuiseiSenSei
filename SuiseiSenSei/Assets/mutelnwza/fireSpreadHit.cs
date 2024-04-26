using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class FireSpreadHit : MonoBehaviour
{
    private FireSpread fr;
    private float Firetime;
    public float AvailableTime;
    private Rigidbody2D rb;

    private void Awake()
    {
        Firetime = Time.time;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        Vector2 position = rb.position;
        Vector2 tomove = new Vector2(0.8f,0);
        rb.MovePosition(position + tomove);
        if (Time.time >= Firetime+AvailableTime)
        {
            Destroy(gameObject);
        }
        
    }
}