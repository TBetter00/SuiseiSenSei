using UnityEngine;

public class Windhit : LongfireHit{

    protected override void Awake(){
        base.Awake();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    protected override void Update()
    {
        base.Update();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.layer == 9){Destroy(gameObject);}
    }
}
