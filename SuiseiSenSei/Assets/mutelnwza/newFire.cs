using UnityEngine;
using System.Collections;

public class NewFire : Skill{

    public bool onActive;
    [SerializeField]private float timer=1f;
    private float force = 15f;
    private Vector3 offset;
    public RigidbodyConstraints2D constraints;
    [SerializeField] private GameObject fire;

    public override void Update()
    {
        if (onActive){
            Cast();}
            SetOffset();
    }

    public override void SkillEnable()
    {
        base.SkillEnable();
        onActive = true;
        // Debug.Log("OnActive :" + onActive);
        StartCoroutine(ActiveDuration());
    }

    public virtual void Cast()
    {
        GameObject firecast = Instantiate(fire, atk.location.position+offset, atk.location.rotation);
        if (atk.location == atk.Leftlocation || atk.location == atk.Rightlocation)
        {
            firecast.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        if (atk.location == atk.Uplocation || atk.location == atk.Downlocation)
        {
            firecast.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        firecast.GetComponent<Rigidbody2D>().AddForce(atk.location.up*force, ForceMode2D.Impulse);
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

    protected virtual IEnumerator ActiveDuration()
    {
        yield return new WaitForSeconds(timer);
        onActive = false;
        // Debug.Log("OnActive :" + onActive);
    }
}