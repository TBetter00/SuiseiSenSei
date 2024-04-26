using UnityEngine;

public class LongfireHit : MonoBehaviour{
    
    protected float Firetime;
    public float AvailableTime;

    protected virtual void Awake()
    {
        Firetime = Time.time;
    }

    protected virtual void Update() {
        if (Time.time >= Firetime+AvailableTime)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("block"))
        {Destroy(gameObject);}
    }
}