using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public float seenEverySeconds;
    private float currentSpeed;
    private GameObject currentTarget;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D myRigitBody = gameObject.AddComponent<Rigidbody2D>();
        myRigitBody.isKinematic = true;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

        if (!currentTarget)
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    void OnTriggerEnter2D()
    {
        Debug.Log(name + " trigger");
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealGamage(damage);
            }
        }
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
