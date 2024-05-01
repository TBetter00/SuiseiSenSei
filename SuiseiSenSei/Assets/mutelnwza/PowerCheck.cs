using UnityEngine;

public class PowerCheck:MonoBehaviour{
    public bool Power;
    public float timetillremove;
    [SerializeField]private float timecount;

    public void Start(){
        Power = false;
        timecount = timetillremove;
    }
    public void Update()
    {
        if (Power)
        {
            timecount -= Time.deltaTime;
            if(timecount <= 0)
            {
                RemovePower();
                timecount = timetillremove; 
            }
        }else if (!Power)
        {
            timecount = timetillremove;
        }
        
    }

    public void AddPower(){
        Power= true;
    }

    public void RemovePower(){
        Power = false;
    }
}