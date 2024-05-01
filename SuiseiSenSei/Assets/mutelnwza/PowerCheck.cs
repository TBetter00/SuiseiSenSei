using UnityEngine;

public class PowerCheck:MonoBehaviour{
    public bool Power;
    public float timetillremove;
    private float timecount;

    public void Start(){
        Power = false;
        timecount = timetillremove;
    }
    public void Update()
    {
        timecount -= Time.deltaTime;
        if(Power = true && timecount >= 0)
        {
            RemovePower();
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