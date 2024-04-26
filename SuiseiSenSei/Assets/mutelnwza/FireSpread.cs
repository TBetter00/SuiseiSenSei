using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;

public class FireSpread : Skill{

    public bool canfire {get; private set;}
    [SerializeField]private float timer = 2f;
    private Vector3 offset;

    [SerializeField]private GameObject fireobject;

    public override void Awake(){
        base.Awake();
        fireobject.SetActive(false);
    }

    public void Update()
    {
        if(!canfire){fireobject.SetActive(false);}
        else if(canfire){
            SetOffset();

            fireobject.transform.localPosition=atk.location.localPosition+offset;
            fireobject.transform.rotation=atk.location.rotation;

            }
    }

    public override void SkillEnable()
    {
        base.SkillEnable();
        
        fireobject.SetActive(true);
        canfire = true;
        StartCoroutine(ActiveDuration());
    }

    private IEnumerator ActiveDuration()
    {
        yield return new WaitForSeconds(timer);
        canfire = false;
    }

    private void SetOffset()
    {
        if(atk.location==atk.Leftlocation){offset= new Vector3(-0.8f,0,0);}
        else if(atk.location==atk.Rightlocation){offset= new Vector3(0.5f,0,0);}
        else if(atk.location==atk.Uplocation){offset= new Vector3(0,0.5f,0);}
        else if(atk.location==atk.Downlocation){offset= new Vector3(0,-0.5f,0);}
    }

    public override void SkillDisable()
    {
        base.SkillDisable();
    }

}