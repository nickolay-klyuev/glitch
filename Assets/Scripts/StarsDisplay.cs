using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarsDisplay : MonoBehaviour
{
    private int starsCount = 0;
    private Text starsText;
    // Start is called before the first frame update
    void Start()
    {
        starsText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddStars(int stars)
    {
        starsCount += stars;
        UpdateDisplay();
    }

    public void UseStars(int stars)
    {
        starsCount -= stars;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starsText.text = starsCount.ToString();
    }
}
