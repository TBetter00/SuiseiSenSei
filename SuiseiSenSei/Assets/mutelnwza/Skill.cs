using System.Runtime.CompilerServices;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public Rigidbody2D rb { get; private set; }
    public AttackInputHandler atk{ get; private set; }
    private Pacmon pacmon;
    public GameObject pacmonpos { get; private set; }

    public virtual void Awake()
    {
        pacmon = GetComponent<Pacmon>();
        rb = GetComponent<Rigidbody2D>();
        atk = GetComponent<AttackInputHandler>();
        pacmonpos = GameObject.Find("pokemon");
    }

    public virtual void SkillEnable()
    {
    }

    public virtual void SkillDisable()
    {
    }
}