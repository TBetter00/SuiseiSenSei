using System.Collections;
using UnityEditor;
using UnityEngine;

public class SpreadHitbox : MonoBehaviour
{
    [SerializeField]private int dmg;
    [SerializeField]private int dmgmultiplier;
    private int finaldmg;
    private Enemy enemy;
    private bool dealingdmg;
    private BigEnemy bigEnemy;
    private Pacmon pacmon;

    private void Awake()
    {
        pacmon = FindObjectOfType<Pacmon>();
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (pacmon.stageMega){finaldmg=dmg*dmgmultiplier;}
        else{finaldmg=dmg;}

        if((collision.gameObject.name =="Blinky" || collision.gameObject.name == "Blinky(Clone)")&&gameObject.activeSelf){
            enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.Die();}

        else if((collision.gameObject.name == "Enemy_Big"|| collision.gameObject.name == "Enemy_Big(Clone)")&&gameObject.activeSelf){
            bigEnemy = collision.gameObject.GetComponent<BigEnemy>();
            dealingdmg = true;
            StartCoroutine(Attacking());}
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.name == "Enemy_Big"|| collision.gameObject.name == "Enemy_Big(Clone)")
        dealingdmg = false;
    }

    private IEnumerator Attacking()
    {
        while(dealingdmg){
            bigEnemy.TakeDamage(finaldmg);

            yield return new WaitForSeconds(0.5f);
        }
    }
}