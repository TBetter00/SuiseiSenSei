using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
<<<<<<< Updated upstream

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
    [HideInInspector] public bool isFright = false;

=======
    public Movement movement {get; private set;}
    public EnemyHome home {get; private set;}
    public EnemyScatter scatter {get; private set;}
    public EnemyChase chase {get; private set;}
    public EnemyFrightened frightened {get; private set;}
    public EnemyBehavior initialBehavior;

    public Transform target;
>>>>>>> Stashed changes

    public int points = 200;

    private void Awake()
    {
<<<<<<< Updated upstream
        this.movement = GetComponent<Movement>();
        this.home = GetComponent<EnemyHome>();
        this.scatter = GetComponent<EnemyScatter>();
        this.chase = GetComponent<EnemyChase>();
        this.frightened = GetComponent<EnemyFrightened>();
        pacmon = FindObjectOfType<Pacmon>();
        gameManager = FindObjectOfType<GameManager>();
        powerCheck = FindObjectOfType<PowerCheck>();

=======
        this.movement = GetComponent<Movement>(); 
        this.home = GetComponent<EnemyHome>(); 
        this.scatter = GetComponent<EnemyScatter>(); 
        this.chase = GetComponent<EnemyChase>(); 
        this.frightened = GetComponent<EnemyFrightened>(); 
>>>>>>> Stashed changes
    }

    private void Start()
    {
        ResetState();
<<<<<<< Updated upstream
        target = GameObject.Find("Pukkermon").transform;
    }

    private void Update()
    {
        if(powerCheck.Power && !isFright)
        {
            isFright = true;
            this.frightened.Enable();
            this.scatter.Disable();
            this.chase.Disable();
            Debug.Log("fright");
        }
        if (pacmon.stageMega)
        {
            isFright = true;
            this.frightened.Enable();
            Debug.Log("megafright");
        }
        else if(!powerCheck.Power || !pacmon.stageMega)
        {
            isFright = false;
        }


        EnsureActiveBehavior();
    }

    public virtual void ResetState()
=======
    }

    public void ResetState()
>>>>>>> Stashed changes
    {
        this.gameObject.SetActive(true);
        this.movement.ResetState();

        this.frightened.Disable();
        this.chase.Disable();
        this.scatter.Enable();
<<<<<<< Updated upstream

        if (this.home != this.initialBehavior)
        {
            this.home.Disable();
        }

        if (this.initialBehavior != null)
        {
=======
        
        if (this.home != this.initialBehavior){
            this.home.Disable();
        }

        if (this.initialBehavior != null){
>>>>>>> Stashed changes
            this.initialBehavior.Enable();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
<<<<<<< Updated upstream
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacmon") && pacmon.GetCurrentStage()!=4)
        {
            if(gameManager.Vulnerable){
                FindObjectOfType<GameManager>().PacmonKilled();
            }
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Pacmon") && pacmon.GetCurrentStage()==4)
        {
            Die();
        }
    }

    public void Die(){
        Instant();
        Destroy(gameObject);
        gameManager.EnemyKilled(points);
    }
    public void Instant()
    {
        Instantiate(Particleprefab,ParticlePos.position, Quaternion.identity);
        Debug.Log("Instanted");
    }

    
    public void HandleStateOnDisable(EnemyBehavior disabledBehavior)
    {
        if (!isFright)
        {
            if (disabledBehavior == chase)
            {
                Debug.Log("Chase disabled, enabling scatter");
                scatter.Enable();
            }
            else if (disabledBehavior == scatter)
            {
                Debug.Log("Scatter disabled, enabling chase");
                chase.Enable();
            }
        }
    }

    private void EnsureActiveBehavior()
    {
        if (!scatter.enabled && !chase.enabled && !frightened.enabled && !home.enabled)
        {
            Debug.Log("No active behavior, enabling scatter as default");
            scatter.Enable();
=======
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacmon"))
        {
            FindObjectOfType<GameManager>().PacmonKilled();
>>>>>>> Stashed changes
        }
    }
}
