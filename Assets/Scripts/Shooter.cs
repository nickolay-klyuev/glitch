using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile, gun;
    private GameObject projectileParent;
    private Animator animator;
    private Spawner laneSpawner;
    
    void Start()
    {
        projectileParent = GameObject.Find("Projectiles");
        if (projectileParent == null)
        {
            projectileParent = new GameObject("Projectiles");
        }
        animator = gameObject.GetComponent<Animator>();

        SetLaneSpawner();
    }

    void Update()
    {
        if (IsAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    bool IsAttackerAheadInLane()
    {
        int attackersCount = laneSpawner.transform.childCount;
        if (attackersCount <= 0)
        {
            return false;
        }
        
        foreach(Transform child in laneSpawner.transform)
        {
            if (child.transform.position.x >= gameObject.transform.position.x)
            {
                return true;
            }
        }

        return false;
    }

    void SetLaneSpawner()
    {
        Spawner[] spawnersArray = GameObject.FindObjectsOfType<Spawner>();

        foreach(Spawner spawner in spawnersArray)
        {
            if (spawner.transform.position.y == gameObject.transform.position.y)
            {
                laneSpawner = spawner;
                return;
            }
        }

        Debug.LogError(name + " can't find spawner");
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
