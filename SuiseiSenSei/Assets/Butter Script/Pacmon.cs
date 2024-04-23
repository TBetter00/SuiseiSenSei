using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Pacmon : MonoBehaviour
{
    public Movement movement {get; private set; }
    public Animator animator;

    public bool walkingUp = false;
    public bool walkingLeft = false;
    public bool walkingRight = false;
    public bool walkingDown = false;


    private void Awake()
    {
        this.movement = GetComponent<Movement>();
        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            this.movement.SetDirection(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            this.movement.SetDirection(Vector2.down);
            resetAllstage();
            animator.SetBool("walkingDown", true);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            this.movement.SetDirection(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            this.movement.SetDirection(Vector2.right);
        }
    }

    private void resetAllstage()
    {
        animator.SetBool("walkingDown", false);
        animator.SetBool("walkingUp", false);
        animator.SetBool("walkingLeft", false);
        animator.SetBool("walkingRight", false);
    }
}
