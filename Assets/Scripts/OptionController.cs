using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionController : MonoBehaviour
{
    public Slider volumeSlider;
    public LevelManager levelManager;
    private MusicManager musicManager;

    void Start()
    {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        levelManager.LoadLevel("01a Start");
    }
}
