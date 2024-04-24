using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Pacmon : MonoBehaviour
{
    public Movement movement { get; private set; }
    public Animator animator;

    public bool stageEgg;
    public bool stage1;
    public bool stage2;
    public bool stage3;
    public bool stageMega;

    public bool blinkingeggto1;
    private bool isBlinkingeggto1;
    public bool blinking1to2;
    private bool isBlinking1to2;

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckUpdate();
        
        if (blinkingeggto1)
        {
            isBlinkingeggto1 = true;
            StartCoroutine(changeeggto1());
            blinkingeggto1 = false;
        }

        if (blinking1to2)
        {
            isBlinking1to2 = true;
            StartCoroutine(change1to2());
            blinking1to2 = false;
        }

        
    }

    private void CheckUpdate()
    {
        switch (GetCurrentStage())
        {
            case 0:
                HandleInputForStage("0");
                break;
            case 1:
                HandleInputForStage("1");
                break;
            case 2:
                HandleInputForStage("2");
                break;
            case 3:
                HandleInputForStage("3");
                break;
            case 4:
                HandleInputForStage("4");
                break;
            default:
                // Handle default case if needed
                break;
        }
    }

    private int GetCurrentStage()
    {
        if (stageEgg)
            return 0;
        else if (stage1)
            return 1;
        else if (stage2)
            return 2;
        else if (stage3)
            return 3;
        else if (stageMega)
            return 4;

        return -1;
    }
    private void HandleInputForStage(string stage)
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.movement.SetDirection(Vector2.up);
            if (movement.Occupied(Vector2.up)){}
            else if (!isBlinkingeggto1 && !isBlinking1to2) { animator.Play(stage + "_upwalk");}
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.movement.SetDirection(Vector2.down);
            if (movement.Occupied(Vector2.down)){}
            else if(!isBlinkingeggto1 && !isBlinking1to2) {animator.Play(stage + "_downwalk");}
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.movement.SetDirection(Vector2.left);
            if (movement.Occupied(Vector2.left)){}
            else if (!isBlinkingeggto1 && !isBlinking1to2) { animator.Play(stage + "_leftwalk");}
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.movement.SetDirection(Vector2.right);
            if (movement.Occupied(Vector2.right)){}
            else if (!isBlinkingeggto1 && !isBlinking1to2) { animator.Play(stage + "_rightwalk");}
        }
    }


    public void ResetState()
    {
        this.movement.ResetState();
        this.gameObject.SetActive(true);
    }

    void setAllstageFalse()
    {
        stageEgg = false;
        stage1 = false;
        stage2 = false;
        stage3 = false;
        stageMega = false;
    }


    IEnumerator changeeggto1()
    {
        animator.Play("changeeggto1");
        yield return new WaitForSeconds(2);
        stageEgg = false;
        stage1 = true;
        isBlinkingeggto1 = false;
    }

    IEnumerator change1to2()
    {
        animator.Play("change1to2");
        yield return new WaitForSeconds(2);
        stage1 = false;
        stage2 = true;
        isBlinking1to2 = false;
    }
}
