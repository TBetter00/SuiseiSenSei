using System.Runtime.CompilerServices;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public Rigidbody2D rb { get; private set; }
    public AttackInputHandler atk{ get; private set; }
    private Pacmon pacmon;
    public GameObject pacmonpos { get; private set; }
    public PowerCheck powerCheck;
    public bool IsAttacking {   get; private set; }
    

    public virtual void Awake()
    {
        pacmon = GetComponentInParent<Pacmon>();
        rb = GetComponent<Rigidbody2D>();
        atk = GetComponentInParent<AttackInputHandler>();
        pacmonpos = GameObject.Find("pokemon");
        powerCheck = FindObjectOfType<PowerCheck>();
    }

    public virtual void SkillEnable()
    {
        powerCheck.RemovePower();
        IsAttacking = true;
    }

    public virtual void SkillDisable()
    {
        IsAttacking = false;
    }
}