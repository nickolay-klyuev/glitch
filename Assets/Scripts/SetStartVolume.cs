using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour
{
    void Start()
    {
        GameObject
            .FindObjectOfType<MusicManager>()
            .ChangeVolume(PlayerPrefsManager.GetMasterVolume());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
