using UnityEngine;

public class FireballHit : MonoBehaviour{
    
    private float Firetime;
    private float AvailableTime=0.4f;

    private void Awake()
    {
        Firetime = Time.time;
    }

    private void Update() {
        if (Time.time >= Firetime+AvailableTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}