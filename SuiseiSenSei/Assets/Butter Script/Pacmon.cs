using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Pacmon : MonoBehaviour
{
    public Movement movement {get; private set; }
    public Animator animator;

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            this.movement.SetDirection(Vector2.up);
            animator.Play("up_walk");
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            this.movement.SetDirection(Vector2.down);
            animator.Play("down_walk");

        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            this.movement.SetDirection(Vector2.left);
            animator.Play("left_walk");
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            this.movement.SetDirection(Vector2.right);
            animator.Play("right_walk");
        }
    }

}
