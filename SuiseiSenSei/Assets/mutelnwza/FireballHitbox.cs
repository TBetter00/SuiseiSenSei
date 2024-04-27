using UnityEngine;

public class FireballHitbox : MonoBehaviour{
    [SerializeField]private int dmg;
    private Enemy enemy;
    private BigEnemy bigEnemy;

    private void Awake()
    {
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log(collision.gameObject.name);
            if(collision.gameObject.name == "Blinky" || collision.gameObject.name == "Blinky(Clone)"){
                enemy = collision.gameObject.GetComponent<Enemy>();
                enemy.Die();
                }
            if(collision.gameObject.name == "Enemy_Big" || collision.gameObject.name == "Enemy_Big(Clone)"){
                bigEnemy = collision.gameObject.GetComponent<BigEnemy>();
                bigEnemy.TakeDamage(dmg);
                }
        }
    }
}