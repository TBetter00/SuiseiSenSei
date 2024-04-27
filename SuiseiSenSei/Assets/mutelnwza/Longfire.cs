using System.Collections;
using System.Threading;
using UnityEngine;

public class Longfire : Skill{

    public bool onActive;
    [SerializeField]private float timer=1f;
    private float force = 15f;
    public RigidbodyConstraints2D constraints;
    [SerializeField] private GameObject fire;

    public virtual void Update()
    {
        if (onActive){
            Cast();}
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
        GameObject firecast = Instantiate(fire, atk.location.position, atk.location.rotation);
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