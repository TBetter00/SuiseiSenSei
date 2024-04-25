using UnityEngine;

public class BigEnemy : Enemy
{

    public float currentHP;
    public float maxHP = 5;
    public HealthbarBehaviour Healthbar;


    private void Start()
    {

        currentHP = maxHP;
        Healthbar.SetHealth(currentHP,maxHP);
    }

    // Override ResetState method to reset HP
    public override void ResetState()
    {
        base.ResetState();
        currentHP = maxHP;

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

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
            Debug.Log(currentHP);
        }
    }

    // Method to handle the death of the big enemy
    private void Die()
    {
        // Implement death logic here
        gameObject.SetActive(false); // Disable the big enemy when it dies
    }


}