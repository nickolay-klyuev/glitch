using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(-1f, 1.5f)]
    public float walkSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D myRigitBody = gameObject.AddComponent<Rigidbody2D>();
        myRigitBody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D()
    {
        Debug.Log(name + " trigger");
    }
}
