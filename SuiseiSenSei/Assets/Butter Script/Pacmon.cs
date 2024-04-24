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

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckUpdate();
    }

    private void CheckUpdate()
    {
        switch (GetCurrentStage())
        {
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
            animator.Play(stage + "_upwalk");
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.movement.SetDirection(Vector2.down);
            animator.Play(stage + "_downwalk");
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.movement.SetDirection(Vector2.left);
            animator.Play(stage + "_leftwalk");
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.movement.SetDirection(Vector2.right);
            animator.Play(stage + "_rightwalk");
        }
    }

}
