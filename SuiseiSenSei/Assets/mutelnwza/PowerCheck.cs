using UnityEngine;

public class PowerCheck:MonoBehaviour{
    public int Power;

    public void Start(){
        Power = 0;
    }

    public void AddPower(){
        Power++;
    }

    public void RemovePower(){
        Power--;
    }
}