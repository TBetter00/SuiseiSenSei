using UnityEngine;

public class LongfireHit : MonoBehaviour{
    
    protected float Firetime;
    public float AvailableTime;

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