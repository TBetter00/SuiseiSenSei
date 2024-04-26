using System.Collections;
using UnityEngine;

public class SpreadHitbox : MonoBehaviour{
    [SerializeField]private int dmg;
    private Enemy enemy;
    private bool dealingdmg;
    private BigEnemy bigEnemy;

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.name =="Blinky"){enemy.Die();}

        else if(collision.gameObject.name == "Enemy_Big"){
            dealingdmg = true;
            StartCoroutine(Attacking());}
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.name == "Enemy_Big")
        dealingdmg = false;
    }

    private IEnumerator Attacking()
    {
        while(dealingdmg){
            bigEnemy.TakeDamage(dmg);

            yield return new WaitForSeconds(0.5f);
        }
    }
}