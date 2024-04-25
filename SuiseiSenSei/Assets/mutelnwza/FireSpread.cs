using UnityEngine;

public class FireSpread : Skill{

    private float Firetime;
    private float AvailableTime=1f;

    public override void Awake()
    {
        base.Awake();
        gameObject.SetActive(false);
    }

    public override void SkillEnable()
    {
        base.SkillEnable();
        Firetime = Time.time;
        
        gameObject.SetActive(true);
    }

    private void Update() {
    if (Time.time >= Firetime+AvailableTime)
    {
        Destroy(gameObject);
    }
    }
}