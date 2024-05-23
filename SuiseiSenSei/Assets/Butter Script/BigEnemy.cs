using UnityEngine;

public class BigEnemy : MonoBehaviour
{

    public float currentHP = 5f;
    public float maxHP = 5f;
    public HealthbarBehaviour Healthbar;


    private void Start()
    {

        currentHP = maxHP;
        Healthbar.SetHealth(currentHP,maxHP);
    }


    // Method to decrease HP when attacked
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Healthbar.SetHealth(currentHP,maxHP);
        if (currentHP <= 0)
        {
            Die();
        }
    }

    // public void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.Space))
    //     {
    //         TakeDamage(1);
    //         Debug.Log(currentHP);
    //     }
    // }

    // Method to handle the death of the big enemy
    private void Die()
    {
        // Implement death logic here
        Destroy(gameObject); // Disable the big enemy when it dies
    }


}