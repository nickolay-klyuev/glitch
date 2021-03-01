using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
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
