using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Fireball : Skill{

    private float force = 15f;
    public RigidbodyConstraints2D constraints;
    [SerializeField] private GameObject fireball;

    public override void Update()
    {
        base.Update();
        if(onActive){Cast();}
    }

    public override void SkillEnable()
    {
        base.SkillEnable();


    }

    private void Cast()
    {
        GameObject firecast = Instantiate(fireball, atk.location.position, atk.location.rotation);
        if (atk.location == atk.Leftlocation || atk.location == atk.Rightlocation)
        {
            firecast.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        firecast.GetComponent<Rigidbody2D>().AddForce(atk.location.up*force, ForceMode2D.Impulse);
    }

    public override void SkillDisable()
    {
        base.SkillDisable();
    }
}