using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Pacmon : MonoBehaviour
{
    public Movement movement { get; private set; }
    public Animator animator;
    public GameManager GameManager;
    

    public bool stageEgg;
    public bool stage1;
    public bool stage2;
    public bool stage3;
    public bool stageMega;
    private String nowStage;
    public bool walkingUp;
    public bool walkingDown;
    public bool walkingLeft;
    public bool walkingRight;

    public bool blinkingeggto1;
    private bool isBlinkingeggto1;
    public bool blinking1to2;
    private bool isBlinking1to2;
    public bool blinking2to3;
    private bool isBlinking2to3;
    public bool blinking3to4;
    private bool isBlinking3to4;
    public bool blinking4to3;
    private bool isBlinking4to3;
    public bool AlreadyBlink1st;
    public bool AlreadyBlink2nd;
    public bool AlreadyBlink3rd;
    public bool AlreadyBlink4th;

    public Palette[] palette;

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
        animator = GetComponent<Animator>();
    }

    private void Start(){
        palette = FindObjectsOfType<Palette>();
    }

    private void Update()
    {
        CheckUpdate();
        ChangeStageWithScore();
        
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

        if (blinking2to3)
        {
            isBlinking2to3 = true;
            StartCoroutine(change2to3());
            blinking2to3 = false;
        }

        if (blinking3to4)
        {
            isBlinking3to4 = true;
            StartCoroutine(change3to4());
            blinking3to4 = false;
        }

        if (blinking4to3)
        {
            isBlinking4to3 = true;
            StartCoroutine(change4to3());
            blinking4to3 = false;
        }
        Debug.Log("Stage :" + GetCurrentStage());
        
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

    public int GetCurrentStage()
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
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            resetallWalk();
            walkingUp = true;
            this.movement.SetDirection(Vector2.up);
            if (movement.Occupied(Vector2.up)){}
            else if (!isBlinkingeggto1 && !isBlinking1to2 && !isBlinking2to3 && !isBlinking3to4 && !isBlinking4to3) { animator.Play(stage + "_upwalk");}
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            resetallWalk();
            walkingDown = true;
            this.movement.SetDirection(Vector2.down);
            if (movement.Occupied(Vector2.down)){}
            else if(!isBlinkingeggto1 && !isBlinking1to2 && !isBlinking2to3 && !isBlinking3to4 && !isBlinking4to3) {animator.Play(stage + "_downwalk");}
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            resetallWalk();
            walkingLeft = true;
            this.movement.SetDirection(Vector2.left);
            if (movement.Occupied(Vector2.left)){}
            else if (!isBlinkingeggto1 && !isBlinking1to2 && !isBlinking2to3 && !isBlinking3to4 && !isBlinking4to3) { animator.Play(stage + "_leftwalk");}
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            resetallWalk();
            walkingRight = true;
            this.movement.SetDirection(Vector2.right);
            if (movement.Occupied(Vector2.right)){}
            else if (!isBlinkingeggto1 && !isBlinking1to2 && !isBlinking2to3 && !isBlinking3to4 && !isBlinking4to3) { animator.Play(stage + "_rightwalk");}
        }

        if (walkingUp)
        {
            if (movement.Occupied(Vector2.up)) { }
            else if (!isBlinkingeggto1 && !isBlinking1to2 && !isBlinking2to3 && !isBlinking3to4 && !isBlinking4to3) { animator.Play(stage + "_upwalk"); }
        }
        else if (walkingDown)
        {
            if (movement.Occupied(Vector2.down)) { }
            else if (!isBlinkingeggto1 && !isBlinking1to2 && !isBlinking2to3 && !isBlinking3to4 && !isBlinking4to3) { animator.Play(stage + "_downwalk"); }
        }
        else if (walkingLeft)
        {
            if (movement.Occupied(Vector2.left)) { }
            else if (!isBlinkingeggto1 && !isBlinking1to2 && !isBlinking2to3 && !isBlinking3to4 && !isBlinking4to3) { animator.Play(stage + "_leftwalk"); }
        }
        else if (walkingRight)
        {
            if (movement.Occupied(Vector2.right)) { }
            else if (!isBlinkingeggto1 && !isBlinking1to2 && !isBlinking2to3 && !isBlinking3to4 && !isBlinking4to3) { animator.Play(stage + "_rightwalk"); }
        }
    }

    private void resetallWalk()
    {
        walkingDown = false;
        walkingUp = false;
        walkingLeft = false;
        walkingRight = false;
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
    public void ChangeStageWithScore()
    {
        if (!blinkingeggto1 && GameManager.score >= 30 && !AlreadyBlink1st)
        {
            blinkingeggto1 = true;
            AlreadyBlink1st = true;

        }
        else if (!blinking1to2 && GameManager.score >= 200 && !AlreadyBlink2nd)
        {
            blinking1to2 = true;
            AlreadyBlink2nd = true;
        }
        else if (!blinking2to3 && GameManager.score >= 500 && !AlreadyBlink3rd)
        {
            blinking2to3 = true;
            AlreadyBlink3rd = true;
        }
        else if (!blinking3to4 && GameManager.score >= 1000 && !AlreadyBlink4th)
        {
            blinking3to4 = true;
            AlreadyBlink4th = true;
        }
    }


    IEnumerator changeeggto1()
    {
        animator.Play("changeeggto1");
        yield return new WaitForSeconds(2);
        setAllstageFalse();
        stage1 = true;
        isBlinkingeggto1 = false;
    }

    IEnumerator change1to2()
    {
        animator.Play("change1to2");
        yield return new WaitForSeconds(2);
        setAllstageFalse();
        stage2 = true;
        isBlinking1to2 = false;
    }

    IEnumerator change2to3()
    {
        animator.Play("change2to3");
        yield return new WaitForSeconds(2);
        setAllstageFalse();
        stage3 = true;
        isBlinking2to3 = false;
    }

    IEnumerator change3to4()
    {
        animator.Play("change3to4");
        yield return new WaitForSeconds(2);
        setAllstageFalse();
        stageMega = true;
        isBlinking3to4 = false;
    }

    IEnumerator change4to3()
    {
        animator.Play("change4to3");
        yield return new WaitForSeconds(2);
        setAllstageFalse();
        stage3 = true;
        isBlinking4to3 = false;
    }
}
