using UnityEngine;

public class PowerCheck:MonoBehaviour{
    public bool Power;
    public float timetillremove;
    [SerializeField]private float timecount;
    public GameObject skillUI;//actually this does'nt do shit
    public GameObject PowerUp;
    private Enemy enemy;
    public Animator animator;

    public void Start(){
        Power = false;
        timecount = timetillremove;
        animator = PowerUp.GetComponent<Animator>();
        PowerUp.SetActive(true);
        
    }
    public void Update()
    {
        if (Power)
        {
            // skillUI.SetActive(true);
            animator.SetBool("isfull",true);
            timecount -= Time.deltaTime;
            if(timecount <= 0)
            {
                RemovePower();
                timecount = timetillremove;
            }
            
        }else if (!Power)
        {
            timecount = timetillremove;
            animator.SetBool("isfull",false);
            // skillUI.SetActive(false);
        }
        
    }

    public void AddPower(){
        Power= true;
        animator.SetTrigger("powerOn");
        timecount = timetillremove;
    }

    public void RemovePower(){
        Power = false;
    }
}