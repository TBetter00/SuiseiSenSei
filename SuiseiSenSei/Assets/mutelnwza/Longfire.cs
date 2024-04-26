using System.Collections;
using System.Threading;
using UnityEngine;

public class Longfire : Skill{

    public bool onActive;
    private float timer=0.5f;
    private float force = 15f;
    public RigidbodyConstraints2D constraints;
    [SerializeField] private GameObject fire;

    public void Update()
    {
        if (onActive){
            SkillEnable();}
    }

    public void Enter()
    {
        onActive = true;
        StartCoroutine(ActiveDuration());
    }

    public override void SkillEnable()
    {
        base.SkillEnable();
        
        GameObject firecast = Instantiate(fire, atk.location.position, atk.location.rotation);
        if (atk.location == atk.Leftlocation || atk.location == atk.Rightlocation)
        {
            firecast.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        firecast.GetComponent<Rigidbody2D>().AddForce(atk.location.up*force, ForceMode2D.Impulse);
    }

    private IEnumerator ActiveDuration()
    {
        yield return new WaitForSeconds(timer);
        onActive = false;
    }
}