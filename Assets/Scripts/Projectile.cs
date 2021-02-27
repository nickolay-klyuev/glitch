using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed, damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject attacker = collider.gameObject;
        if (!attacker.GetComponent<Attacker>())
        {
            return;
        }

        attacker.GetComponent<Health>().DealGamage(damage);
        Destroy(gameObject);
    }
}
