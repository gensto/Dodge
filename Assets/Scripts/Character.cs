using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    Animator anim;
    public CapsuleCollider cc;

    private AnimatorStateInfo currentBaseState;

    static int idleState = Animator.StringToHash("Base Layer.Idle");
    static int jumpingState = Animator.StringToHash("Base Layer.Jumping");
    static int standingToCrouchState = Animator.StringToHash("Base Layer.Standing to crouch");
    static int crouchedToStandingState = Animator.StringToHash("Base Layer.Crouched To Standing");

    // Use this for initialization
    void Start ()
    {
        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        userInput();
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);

        hitBoxColliderTransition();
    }

    void userInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("isCrouching", true);
        }
        else
        {
            anim.SetBool("isCrouching", false);
        }
    }

    void hitBoxColliderTransition()
    {
        if(currentBaseState.fullPathHash == idleState)
        {
            cc.height = anim.GetFloat("ColliderHeight");
            cc.center = new Vector3(0.005772948f, anim.GetFloat("ColliderCenterY"), 0);
        }
        else if(currentBaseState.fullPathHash == standingToCrouchState)
        {
            cc.height = anim.GetFloat("ColliderHeight");
            cc.center = new Vector3(0.005772948f, anim.GetFloat("ColliderCenterY"), 0);
        }
        else if (currentBaseState.fullPathHash == crouchedToStandingState)
        {
            cc.height = anim.GetFloat("ColliderHeight");
            cc.center = new Vector3(0.005772948f, anim.GetFloat("ColliderCenterY"), 0);
        }
        else if(currentBaseState.fullPathHash == jumpingState)
        {
            cc.height = anim.GetFloat("ColliderHeight");
            cc.center = new Vector3(0.005772948f, anim.GetFloat("ColliderCenterY"), 0);
        }
    }

    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "Obstacle")
        {
            Debug.Log("Hello im here bith");
            anim.SetBool("isDead", true);
        }
    }
}
