using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimatorController : MonoBehaviour
{
    public PlayerController playerController = null;
    private Animator animator = null;

    private string trJump = "Jump";
    private string trDeath = "Death";

    private int Jump;
    private int Death;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        Jump = Animator.StringToHash(trJump);
        Death = Animator.StringToHash(trDeath);
    }

    void Update()
    {
        if (playerController.isDead)
        {
            animator.SetBool(Death, true);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector3 input = new Vector3(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);

        if (input.magnitude > 1f) return;


        if (input.magnitude == 0f)
        {
            animator.SetBool(Jump, false);
        }
        else
        {
            animator.SetBool(Jump, true);
        }

    }
}
