using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Movement movement { get; private set; }
    public EnemyHome home { get; private set; }
    public EnemyScatter scatter { get; private set; }
    public EnemyFrightened frightened { get; private set; }
    public EnemyChase chase { get; private set; }
    public Pacmon pacmon { get; private set; }
    public GameObject Particleprefab;
    public Transform ParticlePos;
    public EnemyBehavior initialBehavior;
    public Transform target;
    public GameManager gameManager;
    public PowerCheck powerCheck;


    public int points = 200;

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
        this.home = GetComponent<EnemyHome>();
        this.scatter = GetComponent<EnemyScatter>();
        this.chase = GetComponent<EnemyChase>();
        this.frightened = GetComponent<EnemyFrightened>();
        pacmon = FindObjectOfType<Pacmon>();
        gameManager = FindObjectOfType<GameManager>();
        powerCheck = FindObjectOfType<PowerCheck>();

    }

    private void Start()
    {
        ResetState();
        target = GameObject.Find("Pukkermon").transform;
    }

    private void Update()
    {
        if(powerCheck.Power)
        {
            this.frightened.Enable();
            Debug.Log("fright");
        }
    }

    public virtual void ResetState()
    {
        this.gameObject.SetActive(true);
        this.movement.ResetState();

        this.frightened.Disable();
        this.chase.Disable();
        this.scatter.Enable();

        if (this.home != this.initialBehavior)
        {
            this.home.Disable();
        }

        if (this.initialBehavior != null)
        {
            this.initialBehavior.Enable();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacmon") && pacmon.GetCurrentStage()!=4)
        {
            if(gameManager.Vulnerable){
                FindObjectOfType<GameManager>().PacmonKilled();
            }
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Pacmon") && pacmon.GetCurrentStage()==4)
        {
            Instantiate(Particleprefab,ParticlePos.position, Quaternion.identity);
            Debug.Log("instantiated");
            Die();
        }
    }

    public void Die(){
        Destroy(gameObject);
        gameManager.EnemyKilled(points);
    }
}
