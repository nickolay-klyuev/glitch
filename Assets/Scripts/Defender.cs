using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    public int starsCost = 1;
    private StarsDisplay starsDisplay;

    void Start()
    {
        starsDisplay = GameObject.FindObjectOfType<StarsDisplay>();
    }
    public void AddStars(int stars)
    {
        starsDisplay.AddStars(stars);
    }
}
