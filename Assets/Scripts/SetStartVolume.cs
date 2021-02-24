using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour
{
    private MusicManager musicManager;
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
