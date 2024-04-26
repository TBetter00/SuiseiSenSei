using UnityEngine;

public class FireballHitbox : MonoBehaviour{
    [SerializeField]private int dmg;
    private Enemy enemy;
    private BigEnemy bigEnemy;

    private void Awake()
    {
        enemy = FindObjectOfType<Enemy>();
        bigEnemy = FindObjectOfType<BigEnemy>();
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log(collision.gameObject.name);
            if(collision.gameObject.name == "Blinky"){enemy.Die();}
            if(collision.gameObject.name == "Enemy_Big"){bigEnemy.TakeDamage(dmg);}
        }
    }
}