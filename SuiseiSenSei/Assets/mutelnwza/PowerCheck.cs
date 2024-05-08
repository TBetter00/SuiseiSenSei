using UnityEngine;

public class PowerCheck:MonoBehaviour{
    public bool Power;
    public float timetillremove;
    [SerializeField]private float timecount;
    public GameObject skillUI;
    private Enemy enemy;

    public void Start(){
        Power = false;
        timecount = timetillremove;
        
    }
    public void Update()
    {
        if (Power)
        {
            skillUI.SetActive(true);
            timecount -= Time.deltaTime;
            if(timecount <= 0)
            {
                RemovePower();
                timecount = timetillremove;
            }
            
        }else if (!Power)
        {
            timecount = timetillremove;
            skillUI.SetActive(false);
        }
        
    }

    public void AddPower(){
        Power= true;
        timecount = timetillremove;
    }

    public void RemovePower(){
        Power = false;
    }
}