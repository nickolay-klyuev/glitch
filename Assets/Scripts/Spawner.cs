using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] attackerPrefabArray;

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject thisAttacker in attackerPrefabArray)
        {
            if (isTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
    }

    void Spawn(GameObject objectToSpawn)
    {
        GameObject spawnObject = Instantiate(objectToSpawn) as GameObject;
        spawnObject.transform.parent = transform;
        spawnObject.transform.position = transform.position;
    }

    bool isTimeToSpawn(GameObject attacker)
    {
        Attacker thisAttacker = attacker.GetComponent<Attacker>();
        float spawnDelay = thisAttacker.seenEverySeconds;
        float spawnsPerSecond = 1 / spawnDelay;

        if (Time.deltaTime > spawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }

        float threshold = spawnsPerSecond * Time.deltaTime / 5;

        if (Random.value < threshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
