using System.Runtime.CompilerServices;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public Rigidbody2D rb { get; private set; }
    public AttackInputHandler atk{ get; private set; }
    private Pacmon pacmon;
    public GameObject pacmonpos { get; private set; }
    protected Palette palette;

    public int Power;

    public virtual void Awake()
    {
        pacmon = GetComponentInParent<Pacmon>();
        rb = GetComponent<Rigidbody2D>();
        atk = GetComponentInParent<AttackInputHandler>();
        pacmonpos = GameObject.Find("pokemon");
    }

    public virtual void SkillEnable()
    {
        Power--;
    }

    public virtual void SkillDisable()
    {
    }
}