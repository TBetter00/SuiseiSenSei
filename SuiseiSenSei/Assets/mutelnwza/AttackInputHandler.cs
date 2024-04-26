using Unity.Entities.UniversalDelegates;
using UnityEngine;

public class AttackInputHandler : MonoBehaviour
{
    private Fireball fireball;
    private FireSpread firespread;
    private Longfire longfire;
    private Wind wind;
    private Pacmon pacmon;
    private Skill skill;

    public Transform Leftlocation;
    public Transform Rightlocation;
    public Transform Uplocation;
    public Transform Downlocation;

    public bool atkinput { get; private set; }
    public float StateToAttack { get; private set; }
    public Transform location { get; private set; }
    

    private void Awake()
    {
        pacmon = GetComponent<Pacmon>();
        fireball = GetComponentInChildren<Fireball>();
        firespread = GetComponentInChildren<FireSpread>();
        longfire = GetComponentInChildren<Longfire>();
        wind = GetComponentInChildren<Wind>();
    }

    private void Update()
    {
        LocationCheck();
        StateCheck();
        GetAttackInput();
    }

    public void GetAttackInput()
    {
        if (Input.GetKeyDown("space") && StateToAttack==1 && skill.Power>=1)
        {
            fireball.SkillEnable();
        }

        else if (Input.GetKeyDown("space") && StateToAttack==2 && skill.Power>=1)
        {
            firespread.SkillEnable();
        }

        else if (Input.GetKeyDown("space") && StateToAttack == 3 && skill.Power>=1)
        {
            longfire.SkillEnable();
        }

        else if (Input.GetKeyDown("left ctrl")&&StateToAttack==3 && skill.Power>=1)
        {
            wind.SkillEnable();
        }
    }

    public void LocationCheck()
    {
        if (pacmon.walkingUp) { location = Uplocation; }
        else if (pacmon.walkingDown) { location = Downlocation; }
        else if (pacmon.walkingLeft) { location = Leftlocation; }
        else if (pacmon.walkingRight) { location = Rightlocation; }
    }

    private void StateCheck()
    {
        if (pacmon.stage1) { StateToAttack = 1; }
        else if (pacmon.stage2) { StateToAttack = 2; }
        else if (pacmon.stage3) { StateToAttack = 3; }
        else if (pacmon.stageMega) { StateToAttack = 4; }

        else { StateToAttack = 0; }
    }



}