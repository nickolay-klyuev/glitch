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
        if (spawnObject.GetComponent<Lizard>() != null)
        {
            spawnObject.transform.position = transform.position - new Vector3(3f, 0, 0);
        }
        else
        {
            spawnObject.transform.position = transform.position;
        }
    }

    bool isTimeToSpawn(GameObject attacker)
    {
        Attacker thisAttacker = attacker.GetComponent<Attacker>();
        float spawnDelay = thisAttacker.seenEverySeconds;
        float spawnsPerSecond;
        float difficulty = PlayerPrefsManager.GetDifficulty();
        
        if (difficulty == 1f)
        {
            spawnDelay += .5f;
        }
        else if (difficulty == 3f)
        {
            spawnDelay -= .5f;
        }

        if (Time.realtimeSinceStartup >= 60f)
        {
            spawnsPerSecond = 1 / (spawnDelay - 3f);
        }
        if (Time.realtimeSinceStartup >= 30f)
        {
            spawnsPerSecond = 1 / (spawnDelay - 1f);
        }
        else
        {
            spawnsPerSecond = 1 / spawnDelay;
        }

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
