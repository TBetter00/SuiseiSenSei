using Unity.Entities.UniversalDelegates;
using UnityEngine;

public class AttackInputHandler : MonoBehaviour
{
    private Fireball fireball;
    private FireSpread firespread;
    private Longfire longfire;
    private NewFire newFire;
    private Pacmon pacmon;

    private PowerCheck powerCheck;
    private Palette palette;

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
        powerCheck = GetComponent<PowerCheck>();
        newFire = GetComponentInChildren<NewFire>();
    }

    private void Update()
    {
        LocationCheck();
        StateCheck();
        GetAttackInput();
    }

    public void GetAttackInput()
    {
        if (Input.GetKeyDown("space") && StateToAttack==1 && powerCheck.Power>=1)
        {
            fireball.SkillEnable();
        }

        else if (Input.GetKeyDown("space") && StateToAttack==2 && powerCheck.Power>=1)
        {
            newFire.SkillEnable();
        }

        else if (Input.GetKeyDown("space") && StateToAttack == 3 && powerCheck.Power>=1)
        {
            longfire.SkillEnable();
        }

        else if (Input.GetKeyDown("space") && StateToAttack == 4 && powerCheck.Power>=1)
        {
            longfire.SkillEnable();
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