using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        Attacker attacker = collider.GetComponent<Attacker>();

        if (attacker != null && attacker.GetComponent<Lizard>() != null)
        {
            animator.SetBool("isUnderAttack", true);
        }
        else
        {
            animator.SetBool("isUnderAttack", false);
        }
    }
}
